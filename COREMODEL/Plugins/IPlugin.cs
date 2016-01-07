using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCORE.Plugins
{
    interface IPlugin
    {
        string NAME { get; set; }
        string VERSION { get; set; }

        /// <summary>
        /// Effectue l'installation necessaire au fonctionnement du plugin
        /// Exemple: Création d'une table SQL, d'un dossier de travail, etc ...
        /// </summary>
        void Install();

        string Action();
        string Error();
    }
}
