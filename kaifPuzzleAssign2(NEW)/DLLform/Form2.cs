using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;


namespace DLLform
{
    public partial class Form2 : Form
    {
        private string FullPath;
        private string tempFullPath;
        public string TempDirectory;
        Image LoadImage;
        public string Imagepath;
        public string Textpath;
        public string archiveLocation;
        public string Bintransfering;
        //  private string ;

        public Form2()
        {
            InitializeComponent();


        }
      

        // file caller 
        private void ListFiles()
        {
            
            //Populate the listview with the files and folders from dir
           // textBox1.Text = FullPath;

            //lsv1.Items.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(FullPath);
            try
            {
                DirectoryInfo[] dirList = dirInfo.GetDirectories();
                textBox1.Text = FullPath;
                lsv1.Items.Clear();
                // DirectoryInfo[] dirList = dirInfo.GetDirectories();      
                for (int x = 0; x < dirList.Length; x++)
                {
                    ListViewItem listv = new ListViewItem();
                    listv.Text = dirList[x].Name;
                    listv.SubItems.Add(" ");
                    listv.SubItems.Add(dirList[x].LastAccessTime.ToString());
                    listv.ImageIndex = 0;


                    lsv1.Items.Add(listv);

                }

                FileInfo[] fileList = dirInfo.GetFiles();
                for (int x = 0; x < fileList.Length; x++)
                {
                    ListViewItem listv = new ListViewItem();
                    listv.Text = fileList[x].Name;
                    listv.SubItems.Add(fileList[x].Length.ToString());
                    listv.SubItems.Add(fileList[x].LastAccessTime.ToString());


                    

                    if (fileList[x].Extension == ".mrb")
                    {
                        listv.ImageIndex = 1;
                    }
                    else
                    {
                        listv.ImageIndex = 2;
                    }
                    lsv1.Items.Add(listv);
                }

            }
            catch (System.UnauthorizedAccessException a)
            {
                MessageBox.Show("You need Access, Not Allowed To Enter!");
                
             
            }
            catch (Exception Unhandled)
            {
                MessageBox.Show("NOT CORRECT");
            }


        }
       


        private void Form2_Load(object sender, EventArgs e)
        {

            //Figure out what the debug directory is
            //pass it to ListFiles
            FullPath = Directory.GetCurrentDirectory();

            ListFiles();










        }

        private void button1_Click(object sender, EventArgs e) // load open
        {
            



            //addd protection to make sure a mrb file is actually selected


            if (lsv1.SelectedItems.Count == 1 && lsv1.SelectedItems[0].ImageIndex == 1)
            {



                Imagepath = TempDirectory + @"\puzzle.jpg";
                Textpath = TempDirectory + @"\puzzle.txt";
                Bintransfering = TempDirectory + @"\puzzle.txt";


                this.DialogResult = DialogResult.OK;
              this.Close();
                


            } 
            else 
            {
                MessageBox.Show("Select a file");
            }





            


               
        }

        private void lsv1_Click(object sender, EventArgs e)  
        {



            if (lsv1.SelectedItems.Count == 1)
            {
                

                    //MessageBox.Show(lsv1.SelectedItems[0].Text);

                if (lsv1.SelectedItems[0].ImageIndex == 1)
                { 
                      archiveLocation = FullPath + @"\" + lsv1.SelectedItems[0].Text.ToString();  

                    //if (TempDirectory != "")
                    //{
                    //    RemoveTempDirectory();
                    //}

                    TempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

                    Directory.CreateDirectory(TempDirectory);

                    //Try First
                    ZipArchive archive = ZipFile.OpenRead(archiveLocation);

                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        entry.ExtractToFile(Path.Combine(TempDirectory, entry.FullName), true);
                    }


                   


                    string PicLoc = TempDirectory + @"\puzzle.jpg";
                    string puzzletxt = TempDirectory + @"\puzzle.txt";
                    Bintransfering = TempDirectory + @"\puzzle.txt";



                    string[] lines = System.IO.File.ReadAllLines(puzzletxt);
                    string[] pieces = lines[0].Split(' ');
                    LoadImage = Image.FromFile(PicLoc);


                    string size = Convert.ToInt32(pieces[0]).ToString();
                    txtsize.Text = size.ToString();
                    string ballcount = Convert.ToInt32(pieces[1]).ToString();
                    txtballcount.Text = ballcount.ToString();
                    string wallcount = Convert.ToInt32(pieces[2]).ToString();
                    txtwallcount.Text = wallcount.ToString();



                    //puzzlePictureBox1.Image = Image.FromFile(PicLoc);

                    using (Image temp = Image.FromFile(PicLoc))
                    {
                        Bitmap bm = new Bitmap(puzzlePictureBox1.Width, puzzlePictureBox1.Height);
                        Rectangle r = new Rectangle(0, 0, puzzlePictureBox1.Width, puzzlePictureBox1.Height);
                        Graphics g = Graphics.FromImage(bm);
                        g.DrawImage(temp, r, 0, 0, temp.Width, temp.Height, GraphicsUnit.Pixel);
                        puzzlePictureBox1.Image = bm;
                    }





                }
            }

        }

    

        private void lsv1_DoubleClick(object sender, EventArgs e)
        {

            ListView templsv1 = sender as ListView;

            if (lsv1.SelectedItems.Count == 1)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(FullPath);
              //DirectoryInfo[] dirList = dirInfo.GetDirectories();           // try CATCh DOUBLE CLICK

               // FileInfo[] fileList = dirInfo.GetFiles();


                if (lsv1.SelectedItems[0].ImageIndex == 0)
                {
                    FullPath =  FullPath +@"\"+ lsv1.SelectedItems[0].Text.ToString();


                    ListFiles();
                }
                else if (lsv1.SelectedItems[0].ImageIndex == 1)
                {

                    Imagepath = TempDirectory + @"\puzzle.jpg";
                    Textpath = TempDirectory + @"\puzzle.txt";
                    Bintransfering = TempDirectory + @"\puzzle.txt";
                    Imagepath = TempDirectory;


                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }



            }

            


        }

        private void button2_Click(object sender, EventArgs e) // up one level 
        {

            //DirectoryInfo dirInfo = new DirectoryInfo(FullPath);

            //DirectoryInfo parentInfo = dirInfo.Parent;

            //FullPath = parentInfo.FullName;

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(FullPath);

                DirectoryInfo parentInfo = dirInfo.Parent;

               // tempFullPath = parentInfo.FullName;
               FullPath = parentInfo.FullName;

            }
            catch (System.NullReferenceException z)
            {
                MessageBox.Show("Maxed out!");
                //MessageBox.Show(FullPath);
            }


            ListFiles();
        }

       

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                   // DirectoryInfo dirInfo = new DirectoryInfo(FullPath);
                    FullPath = textBox1.Text.ToString();
                    ListFiles();
                }
            }
            catch (System.UnauthorizedAccessException u)
            {
                MessageBox.Show("Info not correct");
            }
            catch (System.ArgumentException s)
            {
                MessageBox.Show("Info not correct");
            }



        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }
    }
    
}
