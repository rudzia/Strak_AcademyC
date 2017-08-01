using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Snake_Alicja
{
    interface IParticle
    {
        int x { get; set; }
        int y { get; set; }
        Rectangle Rectangle { get; set; }
        void Draw();
    }
}
