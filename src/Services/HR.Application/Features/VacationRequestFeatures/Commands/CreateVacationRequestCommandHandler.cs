using HR.Contracts.VacationRequestContracts;
using HR.Domain.Entities;
using HR.Persistence.Data;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace HR.Application.Features.VacationRequestFeatures.Commands;

internal sealed class CreateVacationRequestCommandHandler : IRequestHandler<CreateVacationRequestCommand, GetVacationRequestDTO?>
{
    private readonly AppDbContext _context;

    public CreateVacationRequestCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetVacationRequestDTO?> Handle(CreateVacationRequestCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FindAsync(new object[] { request.VacationRequestInput.RequestingEmployeeId }, cancellationToken);
        var vacationType = await _context.VacationTypes.AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == request.VacationRequestInput.VacationTypeId, cancellationToken);

        if (employee is null || vacationType is null)
        {
            return null;
        }

        // Deduct Vacation from Employee
        int daysToDeDeducted = GetBusinessDays(request.VacationRequestInput.StartDate, request.VacationRequestInput.EndDate);
        
        if (vacationType.Name == "Annual")
        {
            employee.AnnualVacationRemaining -= daysToDeDeducted;
        }
        else if (vacationType.Name == "Sick")
        {
            employee.SickVacationRemaining -= daysToDeDeducted;
        }

        var newRequest = new VacationRequest
        {
            StartDate = request.VacationRequestInput.StartDate,
            EndDate = request.VacationRequestInput.EndDate,
            VacationTypeId = request.VacationRequestInput.VacationTypeId,
            RequestingEmployeeId = request.VacationRequestInput.RequestingEmployeeId
        };

        await _context.VacationRequests.AddAsync(newRequest, cancellationToken);
        _ = await _context.SaveChangesAsync(cancellationToken);

        return new GetVacationRequestDTO
        {
            ID = newRequest.ID,
            StartDate = newRequest.StartDate,
            EndDate = newRequest.EndDate,
            VacationTypeId = newRequest.VacationTypeId,
            RequestingEmployeeId = newRequest.RequestingEmployeeId
        };
    }

    public int GetBusinessDays(DateTimeOffset firstDay, DateTimeOffset lastDay, params DateTimeOffset[] bankHolidays)
    {
        firstDay = firstDay.Date;
        lastDay = lastDay.Date;
        if (firstDay > lastDay)
            throw new ArgumentException("Incorrect last day " + lastDay);

        TimeSpan span = lastDay - firstDay;
        int businessDays = span.Days + 1;
        int fullWeekCount = businessDays / 7;

        // find out if there are weekends during the time exceedng the full weeks
        if (businessDays > fullWeekCount * 7)
        {
            // we are here to find out if there is a 1-day or 2-days weekend
            // in the time interval remaining after subtracting the complete weeks
            int firstDayOfWeek = (int)firstDay.DayOfWeek;
            int lastDayOfWeek = (int)lastDay.DayOfWeek;
            
            if (lastDayOfWeek < firstDayOfWeek)
                lastDayOfWeek += 7;

            if (firstDayOfWeek <= 6)
            {
                if (lastDayOfWeek >= 7)// Both Saturday and Sunday are in the remaining time interval
                    businessDays -= 2;
                else if (lastDayOfWeek >= 6)// Only Saturday is in the remaining time interval
                    businessDays -= 1;
            }
            else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)// Only Sunday is in the remaining time interval
                businessDays -= 1;
        }

        // subtract the weekends during the full weeks in the interval
        businessDays -= fullWeekCount + fullWeekCount;

        // subtract the number of bank holidays during the time interval
        foreach (DateTimeOffset bankHoliday in bankHolidays)
        {
            DateTimeOffset bh = bankHoliday.Date;

            if (firstDay <= bh && bh <= lastDay)
                --businessDays;
        }

        return businessDays;
    }
}
