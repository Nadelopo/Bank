using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

public class UserType
{
    public int id;
    public long phone;
    public int total;
    public int[] deposits;
    public string passsword;

    public void createUser(int _id, int _total, long _phone, string _password)
    {
        this.id = _id;
        this.total = _total;
        this.phone = _phone;
        this.deposits = new int[6];
        this.passsword = _password;
    }

}

namespace Bank
{
    public partial class App : Application
    {
        public static UserType user = new UserType();
        public static List<UserType> users = new List<UserType>();
    }
}
