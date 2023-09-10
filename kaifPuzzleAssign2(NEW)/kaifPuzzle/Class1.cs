using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kaifPuzzle
{
    class PuzzlePictureBox : PictureBox
    {
        private int row;
        private int column;
        private int ballOrHole;

        private bool topWall;
        private bool bottomWall;
        private bool leftWall;
        private bool rightWall;

        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }

        public int Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
            }
        }

        public int BallOrHole
        {
            get
            {
                return ballOrHole;
            }
            set
            {
                ballOrHole = value;
            }
        }


        public bool TopWall
        {
            get
            {
                return topWall;
            }
            set
            {
                topWall = value;
            }
        }

        public bool BottomWall
        {
            get
            {
                return bottomWall;
            }
            set
            {
                bottomWall = value;
            }
        }

        public bool LeftWall
        {
            get
            {
                return leftWall;
            }
            set
            {
                leftWall = value;
            }
        }

        public bool RightWall
        {
            get
            {
                return rightWall;
            }
            set
            {
                rightWall = value;
            }
        }

    }
}

