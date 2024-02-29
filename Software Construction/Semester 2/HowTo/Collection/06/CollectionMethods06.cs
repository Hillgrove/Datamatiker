
public class CollectionMethods06
{
    /// <summary>
    /// Given a CVR number, find the corresponding Company and return it.
    /// If no Company is found, return null.
    /// </summary>
    public Company? FindCompanyFromCVR(int cvrNo, List<Company> companies)
    {
        // Implement the method as specified in the comment
        foreach (var company in companies)
        {
            if (company.CVRNo == cvrNo)
            {
                return company;
            }
        }
        return null;
    }
}
