namespace AppartmentApi.Enums
{
    public enum MemberQueryType
    {
        FetchAllMembers,

        FetchActiveMembers,
        FetchInactiveMembers,

        FetchOwners,
        FetchActiveOwners,
        FetchInactiveOwners,

        FetchTenents,
        FetchActiveTenents,
        FetchInactiveTenents,

        FetchActiveOwnersAsResidents,
        FetchInactiveOwnersAsResidents
    }
}