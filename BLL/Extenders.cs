using System.Data;

namespace X3Store.BLL
{
    public static class Extenders
    {
        public static void AddUserData(this DataTable userData, string item, string name, string value)
        {
            var row = userData.NewRow();
            row["Item"] = item;
            row["Name"] = name;
            row["Value"] = value;
            userData.Rows.Add(row);
        }
    }
}