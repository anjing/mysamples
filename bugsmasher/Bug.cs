using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMP212_Assignments07
{
    public class Bug
    {
        private int score;
        private int height;
        private int width;
        private int speed;
        
        public Bug(int width, int height)
        {
            score =0;
            speed = 0;
            this.height = height;
            this.width = width;
        }

        public void DetectHit()
        {
            score += 1;
            speed = speed - 200;
            if (speed <= 200 ) 
    	        speed=2400;
        }

        public void ResetScore()
        {
            score = 0;
        }

        public void ResetSpeed()
        {
            speed = 2400;
        }
    }

    public void MoveDot()
    {
    var x = Math.floor(Math.random()*aWidth);
    var y = Math.floor(Math.random()*aHeight);
    
    if(x<10)
        x = 10;
    if(y<10)
        y = 10;
    
    document.getElementById("dot").style.left = x;
    document.getElementById("dot").style.top = y;
    clearTimeout(timer);
    timer = setTimeout("moveDot()",speed);
    }
}



