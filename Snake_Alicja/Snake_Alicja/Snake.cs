using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Snake_Alicja
{
    class Snake
    {
        public PartOfSnake headSnake { get; private set; }
        public List<PartOfSnake> partsSnakeList = new List<PartOfSnake>();
        
        public Snake()
        {
            headSnake = new PartOfSnake(30, 30);
            headSnake.Rectangle.Width = headSnake.Rectangle.Height = 12;
            headSnake.Rectangle.Fill = System.Windows.Media.Brushes.Beige;
        }

        public void DrawSnake()
        {
            Grid.SetColumn(headSnake.Rectangle, headSnake.x);
            Grid.SetRow(headSnake.Rectangle, headSnake.y);

            for (int i = 0; i < partsSnakeList.Count; i++)
            {
                partsSnakeList[i].Draw();
            }
        }
        public PartOfSnake AddParts(int x, int y)
        {
            PartOfSnake part = new PartOfSnake(x, y);
            partsSnakeList.Add(part);
            return part;
        }

        public void updateList(int xDirection, int yDirection)
        {
            PartOfSnake prev = new PartOfSnake(headSnake.x, headSnake.y);
            for(int i = 0; i < partsSnakeList.Count; i++)
            {
                PartOfSnake tmp = new PartOfSnake(partsSnakeList[i].x, partsSnakeList[i].y);
                partsSnakeList[i].x = prev.x;
                partsSnakeList[i].y = prev.y;
                prev.x = tmp.x;
                prev.y = tmp.y;
            }

            headSnake.x += xDirection;
            headSnake.y += yDirection;
        }
    }
}
