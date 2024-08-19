using System;
using Artsofte.Cms.Payload.Employee;
using Artsofte.Database.Employee;

namespace Artsofte.Cms.Codec;

public static class EmployeeCodec
{
    public static EmployeePayload EncodeEmployee(EmployeeModel dbModel)
    {
        return new EmployeePayload
        {
            Id = dbModel.Id,
            Name = dbModel.Name,
            Surname = dbModel.Surname,
            Department = dbModel.Department.Name,
            Language = dbModel.Language.Language,
            Age = dbModel.Age,
            Gender = EncodeGender(dbModel.Gender)
        };
    }


    private static string EncodeGender(Gender dbGender)
    {
        switch (dbGender)
        {
            case Gender.Male:
                return "Male";
            case Gender.Female:
                return "Female";
            default:
                throw new AggregateException($"Undefined encode gender: {dbGender}");
        }
    }
}