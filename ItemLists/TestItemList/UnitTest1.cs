using ItemLists;
using System.Diagnostics;

namespace TestItemList
{
    public class UnitTest1
    {
        [Fact]
        public void ValidAddNewItemList()
        {
            ItemList OptionYes = new();
            OptionYes.AddNew("Yes", "Yes");
            CheckValues(OptionYes, "ValidAddNewItemList"); 
            
            Assert.True(OptionYes.ShowValues() == "Name:Yes- DisplayName:Yes");
            
        }

        [Fact]
        public void InValidAddNewItemListInvalidSQLChars()
        {
            ItemList OptionYes = new();
            OptionYes.AddNew("Yes'", "Yes'");
            CheckValues(OptionYes, "InValidAddNewItemListInvalidSQLChars");

            Assert.True(OptionYes.ShowValues() == "Name:Yes- DisplayName:Yes");
        }
        [Fact]
        public void InValidAddNewItemListInvalidSQLCharsDoubleRoutes()
        {
            ItemList OptionYes = new();
            OptionYes.AddNew("Yes\"", "Yes\"");
            CheckValues(OptionYes, "InValidAddNewItemListInvalidSQLCharsDoubleRoutes");
            Assert.True(OptionYes.ShowValues() == "Name:Yes- DisplayName:Yes");
        }

        [Fact]
        public void ValidAddItemListWithInvalidGUID()
        {
            ItemList OptionYes = new();
            OptionYes.Add("Yes\"", "Yes\"","12-12");
            CheckValues(OptionYes, "ValidAddItemListWithInvalidGUID");

            Assert.True(OptionYes.ErrorCodes == "axaaa99");
        }

        [Fact]
        public void ValidAddItemListWithValidGUID()
        {
            ItemList OptionYes = new();
            OptionYes.Add("Yes\"", "Yes\"", "8b5d025d-94ae-4bb6-9e0c-7c9350695f94");
            CheckValues(OptionYes, "ValidAddItemListWithValidGUID");

            Assert.False(OptionYes.ErrorCodes == "axaaa99");
        }

        private static void CheckValues(ItemList OptionYes, string title)
        {
            DateTime? CreatedDate = OptionYes?.CreatedDate;
            DateTime? ModifyDate = OptionYes?.LastModifiedDate;
            DateTime? RemoveDate = OptionYes?.RemoveDate;
            UInt16? Active = OptionYes?.IsActive;
            UInt16? Remove = OptionYes?.IsRemoved;
            string? GUID = OptionYes?.GUID;
            string? ErrorCodes = OptionYes?.ErrorCodes;
            string? CodesLog = OptionYes?.CodesLog;
            Debugger.Log(1, "w", $"\n{title}");
            Debugger.Log(1, "w", $"\n-----------------------------");
            Debugger.Log(1, "w", $"\nCreateDate: {CreatedDate}");
            Debugger.Log(1, "w", $"\nModifyDate: {ModifyDate}");
            Debugger.Log(1, "w", $"\nRemovedDate: {RemoveDate}");
            Debugger.Log(1, "w", $"\nActive: {Active}");
            Debugger.Log(1, "w", $"\nRemove: {Remove}");
            Debugger.Log(1, "w", $"\nGUID: {GUID}");
            Debugger.Log(1, "w", $"\nErrorCode: {ErrorCodes}");
            Debugger.Log(1, "w", $"\nCodesLog: {CodesLog}");
        }
    }
}