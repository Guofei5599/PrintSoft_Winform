using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 打印管理
{
    public class RowComparer : System.Collections.IComparer
    {
        #region
        private static int sortOrderModifier = 1;

        public RowComparer(SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Descending)
            {
                sortOrderModifier = -1;
            }
            else if (sortOrder == SortOrder.Ascending)
            {
                sortOrderModifier = 1;
            }
        }

        public int Compare(object x, object y)
        {
            DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
            DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;

            // Try to sort based on the Last Name column.
            int CompareResult = System.String.Compare(
                DataGridViewRow1.Cells["State"].Value.ToString(),
                DataGridViewRow2.Cells["State"].Value.ToString());

            // If the Last Names are equal, sort based on the First Name.
            //if (CompareResult == 0)
            //{
            //    CompareResult = System.String.Compare(
            //        DataGridViewRow1.Cells["isManual"].Value.ToString(),
            //        DataGridViewRow2.Cells["isManual"].Value.ToString());
            //}
            return CompareResult * sortOrderModifier;
        }
        #endregion
    }

    public class RowComparerUser : System.Collections.IComparer
    {
        #region
        private static int sortOrderModifier = 1;
        private static int MainsortOrderModifier = 1;
        private string name = "";
        public RowComparerUser(SortOrder sortOrder, SortOrder MainsortOrder,string Name)
        {
            name = Name;
            if (sortOrder == SortOrder.Descending)
            {
                sortOrderModifier = -1;
            }
            else if (sortOrder == SortOrder.Ascending)
            {
                sortOrderModifier = 1;
            }
            if (MainsortOrder == SortOrder.Descending)
            {
                MainsortOrderModifier = -1;
            }
            else if (MainsortOrder == SortOrder.Ascending)
            {
                MainsortOrderModifier = 1;
            }
        }

        public int Compare(object x, object y)
        {
            DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
            DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;

            // Try to sort based on the Last Name column.
            int CompareResult = System.String.Compare(
                DataGridViewRow1.Cells["State"].Value.ToString(),
                DataGridViewRow2.Cells["State"].Value.ToString());

            // If the Last Names are equal, sort based on the First Name.
            //if (CompareResult == 0)
            //{
            //    CompareResult = System.String.Compare(
            //        DataGridViewRow1.Cells["isManual"].Value.ToString(),
            //        DataGridViewRow2.Cells["isManual"].Value.ToString());
            //}
            if (CompareResult == 0)
            {
                if (name == "时间")
                {
                    string s1 = DataGridViewRow1.Cells[name].Value == null ? "" : DataGridViewRow1.Cells[name].Value.ToString();
                    string s2 = DataGridViewRow2.Cells[name].Value == null ? "" : DataGridViewRow2.Cells[name].Value.ToString();
                    List<string> TimeList = new List<string>();
                    foreach (var v1 in FileHelper.timelist)
                        TimeList.Add(v1.TimeOfDay.ToString().Substring(0, 5));
                    string indexstr1 = TimeList.IndexOf(s1).ToString();
                    string indexstr2 = TimeList.IndexOf(s2).ToString();
                    CompareResult = System.String.Compare(indexstr1,indexstr2);
                }
            }
            else
                return CompareResult * MainsortOrderModifier;
            return CompareResult * sortOrderModifier;
        }
        #endregion
    }

    public class RowComparerUserState : System.Collections.IComparer
    {
        #region
        private static int sortOrderModifier = 1;
        private static int lowSortOrderModifier = 1;
        private static int MainsortOrderModifier = 1;
        private string name = "";
        public RowComparerUserState(SortOrder lowSortOrder, SortOrder sortOrder, SortOrder MainsortOrder, string Name)
        {
            name = Name;
            if (lowSortOrder == SortOrder.Descending)
            {
                lowSortOrderModifier = -1;
            }
            else if (lowSortOrder == SortOrder.Ascending)
            {
                lowSortOrderModifier = 1;
            }
            if (MainsortOrder == SortOrder.Descending)
            {
                MainsortOrderModifier = -1;
            }
            if (sortOrder == SortOrder.Descending)
            {
                sortOrderModifier = -1;
            }
            else if (sortOrder == SortOrder.Ascending)
            {
                sortOrderModifier = 1;
            }
            if (MainsortOrder == SortOrder.Descending)
            {
                MainsortOrderModifier = -1;
            }
            else if (MainsortOrder == SortOrder.Ascending)
            {
                MainsortOrderModifier = 1;
            }
        }

        public int Compare(object x, object y)
        {
            DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
            DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;

            // Try to sort based on the Last Name column.
            int CompareResult = System.String.Compare(
                DataGridViewRow1.Cells["State"].Value.ToString(),
                DataGridViewRow2.Cells["State"].Value.ToString());

            // If the Last Names are equal, sort based on the First Name.
            //if (CompareResult == 0)
            //{
            //    CompareResult = System.String.Compare(
            //        DataGridViewRow1.Cells["isManual"].Value.ToString(),
            //        DataGridViewRow2.Cells["isManual"].Value.ToString());
            //}
            if (CompareResult == 0)
            {
                string s1 = DataGridViewRow1.Cells["时间"].Value == null ? "" : DataGridViewRow1.Cells["时间"].Value.ToString();
                string s2 = DataGridViewRow2.Cells["时间"].Value == null ? "" : DataGridViewRow2.Cells["时间"].Value.ToString();
                List<string> TimeList = new List<string>();
                foreach (var v1 in FileHelper.timelist)
                    TimeList.Add(v1.TimeOfDay.ToString().Substring(0, 5));
                string indexstr1 = TimeList.IndexOf(s1).ToString();
                string indexstr2 = TimeList.IndexOf(s2).ToString();
                CompareResult = System.String.Compare(indexstr1, indexstr2);
            }
            else
                return CompareResult * MainsortOrderModifier;
            if (CompareResult == 0)
            {
                if (name == "地址")
                {
                    string s1 = DataGridViewRow1.Cells[name].Value == null ? "" : DataGridViewRow1.Cells[name].Value.ToString();
                    string s2 = DataGridViewRow2.Cells[name].Value == null ? "" : DataGridViewRow2.Cells[name].Value.ToString();
                    List<string> TimeList = new List<string>();
                    string indexstr1 = FileHelper.addrList.IndexOf(s1).ToString();
                    string indexstr2 = FileHelper.addrList.IndexOf(s2).ToString();
                    CompareResult = System.String.Compare(indexstr1, indexstr2);
                }
                else
                    CompareResult = System.String.Compare(
                    Convert.ToString( DataGridViewRow1.Cells[name].Value),
                    Convert.ToString(DataGridViewRow2.Cells[name].Value));
            }
            else
                return CompareResult * sortOrderModifier;
            return CompareResult * lowSortOrderModifier;
        }
        #endregion
    }
}
