using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerSide
{
    /// <summary>
    /// האפליקציה זאת - מוקד ההודעות
    /// כל משתתף בצאט יצטרך להתחבר לשרת ולתקשר מולו.
    /// הודעוה נשלחות לשרת  אשר יפיץ אותם לכל שאר המשתתפים
    /// ובחזרה שולח את ההודעות שמשתתפים אחרים שלחו דרכו 
    /// 
    /// האפליקציה תאפשר למפעיל תוכנת השרת לבחור כתובת ופורט 
    /// של המחשב המריץ את אפליקציה השרת
    ///  בצד השרת יהיה ניתן לראות את שמות כל המשתתפים בכל רגע נתון
    ///  ובנוסף ניתן את ההיסטוריה של המשתתפים שהיו בצאט
    ///  
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerForm());
        }
    }
}
