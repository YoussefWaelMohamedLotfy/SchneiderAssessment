﻿namespace HR.Contracts.VacationRequestContracts;

public class CreateVacationRequestDTO
{
    public Guid RequestingEmployeeId { get; set; }

    public int VacationTypeId { get; set; }

    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset EndDate { get; set; }
}
