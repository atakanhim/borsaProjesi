using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace borsaProjesi
{
    public sealed class Singleton // bu class birden fazla kullanılan nesneleri bulunduruyor
    {
        private Singleton()
        {
        }
        private static Singleton instance = null;
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        public void ExitTheApplication() => Application.Exit();// uygullamayı sonlandırıyopr
        public void ChangeScreen(Form hide, Form show)// ekran degistiriyor
        {
            hide.Hide();
            show.Show();
           
        }
        // Classlar
        public CurrentUser currentUser = new CurrentUser();
        public DataIslemleri islem = new DataIslemleri();


        //Form Classları
        public MainScreen main = new MainScreen();
        public SignUp signUp = new SignUp();
        public Login login = new Login();
        public AdminGirisForm admingiris = new AdminGirisForm();
        public AdminForm adminForm = new AdminForm();
        public GirisControl girisctr = new GirisControl();

    }
}
