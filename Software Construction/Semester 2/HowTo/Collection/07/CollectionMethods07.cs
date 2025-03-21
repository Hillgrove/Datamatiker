﻿
public class CollectionMethods07
{
    /// <summary>
    /// Given a CVR number, find the corresponding Company and return it.
    /// If no Company is found, return null.
    /// </summary>
    public Company? FindCompanyFromCVR(int cvrNo, List<Company> companies)
    {
        foreach (Company company in companies)
        {
            if (company.CVRNo == cvrNo)
                return company;
        }

        return null;
    }

    /// <summary>
    /// Given a number of employees, find all companies having at least that
    /// number of employees. Return the companies as a List.
    /// </summary>
    public List<Company> FindCompaniesByEmployees(int noOfEmployees, List<Company> companies)
    {
        List<Company> resultList = new List<Company>();

        // Implement the method as specified in the comment
        foreach (Company company in companies)
        {
            if (company.NoOfEmployees >= noOfEmployees)

                    resultList.Add(company);
        }

        return resultList;
    }
}
