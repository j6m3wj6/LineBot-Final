
using System;
using isRock.LineBot;

namespace LineBot.Components
{
    public class RichMenu
    {
        public RichMenuArea Area;
        public isRock.LineBot.RichMenu.RichMenuItem Item;
        public RichMenu()
        {
            Area = new RichMenuArea();
            Item = new isRock.LineBot.RichMenu.RichMenuItem();
        }
        public void CreateArea(int bound_x, int bound_y, int w, int h, MessageAction act)
        {
            Area = new RichMenuArea(bound_x, bound_y, w, h, act);
        }
        public void AddtoItem(RichMenuArea area)
        {
            Item.areas.Add(area);
        }
    }
    public class RichMenuArea : isRock.LineBot.RichMenu.Area
    {
        public RichMenuArea() : base()
        {
        }
        public RichMenuArea(int bound_x, int bound_y, int w, int h, MessageAction act) : base()
        {
            bounds.x = bound_x;
            bounds.y = bound_y;
            bounds.width = w;
            bounds.height = h;
            action = act;
        }


    }
}

