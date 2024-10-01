namespace ItemLists
{
    public class StandardProperties
    {
        public DateTime? CreatedDate { get; set; } = default; // #5
        public string? GUID { get; set; } // #3
        public UInt16? IsActive { get; set; } //#5 #12
        public UInt16? IsRemoved { get; set; } //#5 #12
        public DateTime? LastModifiedDate { get; set; } // #5
        public DateTime? RemoveDate { get; set; } // #5
        public string? Version { get; set; } //#14
        public bool ValueAdded { get; set; } //#8
    }
}