using StandardUtilities;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Text;

namespace ItemLists
{
    public class ItemList : StandardProperties, IItemListBase
    {
        //**************************************************************************************************************************
        //#1    Created - Property - Name - must be unique.                                             TB10                20240908
        //#2    Created - Property - DisplayName                                                        TB10                20240908
        //#3    Created - Property - GUID                                                               TB10                20240908
        //#4    Created - Method - ItemList with - properties - name, display all strings               TB10                20240908 
        //#5    Created - CreatedDate, LastModifiedDate, RemoveDate, IsActive                           TB10                20240909
        //#6    Created - CodesLog - tracking code on what was executed for debugging                   TB10                20240909
        //#7    Created - Constructor - ItemList - default IsActive (true), ValueSet (t) IsDeleted(t)   TB10                20240909
        //#8    Created - ValueSet - bool                                                               TB10                20240909
        //#9    Created - Modify - To modify the DisplayName.                                           TB10                20240909
        //#10   Created - Remove - To mark the item (IsRemoved)                                         TB10                20240909
        //#11   Created - Method - CleanGuid                                                            TB10                20240909
        //#12   Changed - Type from bool to uint16 - to simplify SQL saving                             TB10                20240909 
        //#13   Created - Property - ErrorCodes                                                         TB10                20240909
        //#14   Created - Properties - Version                                                          TB10                20240909
        //#15   Add     - Version                                                                       TB10                20240909
        //**************************************************************************************************************************
        #region Properties
        private string? Name { get; set; } // #1
        private string? DisplayName { get; set; } // #2
        public string? CodesLog { get; set; }
        public string? ErrorCodes { get; set; }

        private readonly Utilities? utilities;
        private readonly StringBuilder? errorCodes;
        private readonly StringBuilder? codesLog;
        public ItemList() 
        {
            try
            {
                IsActive = 1;
                ValueAdded = false;
                IsRemoved = 0;
                Version = "1.15.0";
                utilities = new();
                errorCodes = new();
                codesLog = new();
                codesLog.Append("aaaaaa1");
            }
            catch (Exception ex)
            {
                ExceptionMethod(ex);
            }
        } //#7 #15
        #endregion

        /// <summary>
        /// Add a new Item list item.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        public void AddNew(string name, string displayName) 
        {
            try
            {
                if (ContinueToAdd())
                {
                    ValidateUtilitiesReference();
                    if (string.IsNullOrEmpty(name)) { throw new Exception("axaaaa3"); }
                    if (string.IsNullOrEmpty(displayName)) { throw new Exception("axaaaa4"); }
                    if (codesLog == null) { throw new Exception("axaaaa11"); }

                    string guid = Utilities.GetGUID();
                    Add(name, displayName, guid);
                    ValueAdded = true;
                    codesLog.Append("aaaaaa2");
                    CodesLog = codesLog.ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionMethod(ex);
            }
        } // #4


        /// <summary>
        /// Add an existing item - only if the AddNew was not called or if the Add was called twice.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        /// <param name="guid"></param>
        public void Add(string name, string displayName, string guid) 
        {
            try
            {
                if (ValueAdded == false)
                {
                    ValidateUtilitiesReference();
                    if (!Guid.TryParse(guid, out Guid guidOutput)) { throw new Exception("axaaa99"); }
                    if (string.IsNullOrEmpty(name)) { throw new Exception("axaaaa6"); }
                    if (string.IsNullOrEmpty(displayName)) { throw new Exception("axaaaa7"); }
                    if (string.IsNullOrEmpty(guid)) { throw new Exception("axaaaa8"); }

                    Name = Utilities.CleanString(name);
                    DisplayName = Utilities.CleanString(displayName);
                    GUID = guid;
                    CreatedDate = Utilities.FormatCurrentDate();
                    ValueAdded = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionMethod(ex);
            }
        } // #4

        /// <summary>
        /// Modify the displayName only.
        /// </summary>
        /// <param name="displayName"></param>
        public void Modify(string displayName) 
        {
            try
            {
                if (IsRemoved == 0 || IsActive == 0)
                {
                    ValidateUtilitiesReference();
                    LastModifiedDate = Utilities.FormatCurrentDate();
                    DisplayName = Utilities.CleanString(displayName);
                }
            }
            catch (Exception ex)
            {
                ExceptionMethod(ex);
            }
        } // #9

        /// <summary>
        /// Mark the record as remove.
        /// </summary>
        public void Remove() 
        {
            try
            {
                ValidateUtilitiesReference();
                RemoveDate = Utilities.FormatCurrentDate();
                IsRemoved = 1;
                IsActive = 0;
            }
            catch (Exception ex)
            {
                ExceptionMethod(ex);
            }
        } // #10

        public string ShowValues()
        {
            return $"Name:{Name}- DisplayName:{DisplayName}";
        }

        //Local Helper Methods
        private void ExceptionMethod(Exception ex)
        {
            if (errorCodes != null)
            {
                errorCodes.Append(ex.Message);
                ErrorCodes = errorCodes.ToString();
                errorCodes.Clear();
            }
            else
            {
                throw ex;
            }
        }

        private bool ContinueToAdd()
        {
            return ValueAdded == false;
        }

        private void ValidateUtilitiesReference()
        {
            if (utilities == null) throw new Exception("axaaaa2");
        }
    }
}