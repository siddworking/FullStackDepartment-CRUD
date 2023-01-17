namespace DAL;
using BOL;

public class LoginManager{

    public List<Login> GetLogins()
    {
        using(var log = new Logdemo())
        {
            var log1 = from loging in log.Logins select loging;
            return log1.ToList<Login>();
        }
    }
}