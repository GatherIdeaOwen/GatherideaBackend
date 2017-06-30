using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestData : MonoBehaviour
{
    public UserData User()
    {
        UserData ud = new UserData("shark1", "", 0, 0);
        return ud;
    }

    public static List<CustomerTypeData> customerTypeList()
    {
        List<CustomerTypeData> ctd = new List<CustomerTypeData>();
        ctd.Add(new CustomerTypeData(0, "廠商總覽"));
        ctd.Add(new CustomerTypeData(1, "熱搜廠商"));
        ctd.Add(new CustomerTypeData(2, "北京廠商"));
        ctd.Add(new CustomerTypeData(3, "上海廠商"));
        ctd.Add(new CustomerTypeData(4, "黑人問號1"));
        ctd.Add(new CustomerTypeData(5, "黑人問號2"));
        ctd.Add(new CustomerTypeData(6, "黑人問號3"));
        return ctd;
    }

    public static List<CustomerData> customerDataList()
    {
        List<string> games = new List<string>();
        games.Add("game1");
        games.Add("game2");
        games.Add("game3");
        List<CustomerData> list = new List<CustomerData>();
        list.Add(new CustomerData(0, 0){ meetingCheck = true, companyName = "aaaa", personName = "a1111" });
        list.Add(new CustomerData(0, 1){ mailedCheck = true, companyName = "bbbb", personName = "b1111" });
        list.Add(new CustomerData(1, 1){ meetingCheck = true, companyName = "cccc", personName = "c1111" });
//        list.Add(new CustomerData(0, true, 0, "wqrqe", "1", "1", "1", "1", "1", "1", "1", "1", "1", null, "1"));
//        list.Add(new CustomerData(1, true, 0, "wqrqe1", "2", "2", "2", "2", "2", "2", "2", "2", "2", games, "2"));
//        list.Add(new CustomerData(2, false, 0, "wqrqe2", "3", "3", "3", "3", "3", "3", "3", "3", "3", null, "3"));
//        list.Add(new CustomerData(3, false, 0, "wqrqe3", "4", "4", "4", "4", "4", "4", "4", "4", "4", games, "4"));
//        list.Add(new CustomerData(4, true, 0, "wqrqe4", "5", "5", "5", "5", "5", "5", "5", "5", "5", null, "5"));
//        list.Add(new CustomerData(5, false, 1, "wqrqe5", "6", "6", "6", "6", "6", "6", "6", "6", "6", games, "6"));
//        list.Add(new CustomerData(6, true, 1, "wqrqe6", "7", "7", "7", "7", "7", "7", "7", "7", "7", games, "7"));
//        list.Add(new CustomerData(7, true, 2, "wqrqe7", "8", "8", "8", "8", "8", "8", "8", "8", "8", null, "8"));
//        list.Add(new CustomerData(8, false, 3, "wqrqe8", "9", "9", "9", "9", "9", "9", "9", "9", "9", null, "9"));
//        list.Add(new CustomerData(9, true, 4, "wqrqe9", "10", "10", "10", "10", "10", "10", "10", "10", "10", games, "10"));
        return list;
    }

    public static List<CooperationData> cooperationDataList()
    {
        List<CooperationData> list = new List<CooperationData>();
        list.Add(new CooperationData(0, "111", "Company1", "Person1", "001", "0901", "@1", "#1"));
        list.Add(new CooperationData(1, "222", "Company2", "Person2", "002", "0902", "@2", "#2"));
        list.Add(new CooperationData(2, "333", "Company3", "Person3", "003", "0903", "@3", "#3"));
        list.Add(new CooperationData(3, "444", "Company4", "Person4", "004", "0904", "@4", "#4"));
        list.Add(new CooperationData(4, "555", "Company5", "Person5", "005", "0905", "@5", "#5"));
        list.Add(new CooperationData(5, "666", "Company6", "Person6", "006", "0906", "@6", "#6"));
        list.Add(new CooperationData(6, "777", "Company7", "Person7", "007", "0907", "@7", "#7"));
        list.Add(new CooperationData(7, "888", "Company8", "Person8", "008", "0908", "@8", "#8"));

        return list;
    }


}
