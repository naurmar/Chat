using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    /// <summary>
    /// אפליקציית צד הלקוח לא יכולה לדעת אילו משתמשים נוספים קיימים ברשת
    /// מה כתובת שלהם  אשר משתתפים בצאט .
    ///האפליקציה תאפשר למשתמש לבחור:
    ///   *כתובת ופורט של המחשב שמריץ את אפליקציית השרת
    ///   *שם משתמש, בכדי שמשתמים אחרים ידעו ממי הם קיתלו את ההודעה
    ///   *צבע הגופן, כך שהודעות ממשתתף מסוים יופיעו בצבע שהוא בחר
    ///האפליקציה תאפשר למשתמש להקליד הודעה ולשלוח אותה לשרת
    ///האפליקציה תציג את כל ההודעות שהשרת שולח למשתמש
    ///אפשרות להתנתק ולהתחבר שוב
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
            Application.Run(new ClientForm());
        }
    }
}
