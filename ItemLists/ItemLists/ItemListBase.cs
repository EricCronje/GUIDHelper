namespace ItemLists
{
    public interface IItemListBase
    {
        public string? CodesLog { get; set; } //#6
        public string? ErrorCodes { get; set; } //#13

        void Add(string name, string displayName, string guid);
        void AddNew(string name, string displayName);
        void Modify(string displayName);
        void Remove();
    }
}