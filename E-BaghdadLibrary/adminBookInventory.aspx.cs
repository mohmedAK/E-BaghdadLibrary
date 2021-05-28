using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELibrary.Controller;
using ELibrary.Model;
namespace ELibrary
{
    public partial class adminBookInventory : System.Web.UI.Page
    {
        CMD_AuthorMaster CMD_Author = new CMD_AuthorMaster();
        CMD_PublisherMaster CMD_Publisher = new CMD_PublisherMaster();
        CMD_BookMaster CMD_Book = new CMD_BookMaster();
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAuthorPublisherValues();
            }
            GridView1.DataBind();
        }

      

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxBookId.Text) || string.IsNullOrWhiteSpace(TextBoxBookName.Text))
            {
                Response.Write("<script>alert('Please Fill Book Id or Book Name Field'); </script>");
                return;
            }

            if (CheckBookExist())
            {
                Response.Write("<script>alert('Book Id Already Existing Enter Another Book Id'); </script>");
            }
            else
            {
                AddNewBook();
                GridView1.DataBind();
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxBookId.Text) || string.IsNullOrWhiteSpace(TextBoxBookName.Text))
            {
                Response.Write("<script>alert('Please Fill Book Id or Book Name Field'); </script>");
                return;
            }
            if (CheckBookExist())
            {
                UpdateBook();
                GridView1.DataBind();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxBookId.Text) || string.IsNullOrWhiteSpace(TextBoxBookName.Text))
            {
                Response.Write("<script>alert('Please Fill Book Id or Book Name Field'); </script>");
                return;
            }
            if (CheckBookExist())
            {
                DeleteBook();
                GridView1.DataBind();
            }
        }

        void fillAuthorPublisherValues()
        {
            List<CLS_AuthorMaster> Authors = CMD_Author.GetAllAuthor();
            Authors.ForEach(c =>
            {
                DropDownListAuthorNames.Items.Add(c.author_name);
            });
            
            List<CLS_PublisherMaster> Publisher = CMD_Publisher.GetAllPublisher();
            Publisher.ForEach(c =>
            {
                DropDownListPublisher.Items.Add(c.publisher_name);
            });
             
        }

        void AddNewBook()
        {
            string genres = "";
            foreach (int item in ListBoxGenre.GetSelectedIndices())
            {
                genres += ListBoxGenre.Items[item] + ",";
            }
            genres = genres.Remove(genres.Length - 1);


            string filepath = "~/book_inventory/books1.png";
            string filename = Path.GetFileName(FileUpload.PostedFile.FileName);
            if (filename == "" || filename == null)
            {
                filepath = global_filepath;

            }
            else
            {
                FileUpload.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;
            }


            CLS_BookMaster book = new CLS_BookMaster()
            {
                book_id = TextBoxBookId.Text.Trim(),
                book_name = TextBoxBookName.Text.Trim(),
                no_of_page = TextBoxPage.Text.Trim(),
                language = DropDownListLanguage.SelectedItem.Value,

                author_name = DropDownListAuthorNames.SelectedItem.Value,
                publisher_name = DropDownListPublisher.SelectedItem.Value,
                publisher_date = TextBoxPublishDate.Text.Trim(),
                book_cost = TextBoxBookCost.Text.Trim(),
                book_description = TextBoxBookDescription.Text.Trim(),
                edition = TextBox1Edition.Text.Trim(),
                actual_stock = TextBoxActualStock.Text.Trim(),
                current_stock = TextBoxActualStock.Text.Trim(),
                genre = genres,
                book_img_link = filepath


            };

            CMD_Book.InsertBook(book);
        }

     

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxBookId.Text) )
            {
                Response.Write("<script>alert('Please Fill Book Id  Feild'); </script>");
                return;
            }
            GetBookById();
        }


        void UpdateBook()
        {
            int actual_stock = Convert.ToInt32(TextBoxActualStock.Text.Trim());
            int current_stock = Convert.ToInt32(TextBoxCurrentStock.Text.Trim());

            if (global_actual_stock == actual_stock)
            {

            }
            else
            {
                if (actual_stock < global_issued_books)
                {
                    Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                    return;


                }
                else
                {
                    current_stock = actual_stock - global_issued_books;
                    TextBoxCurrentStock.Text = "" + current_stock;
                }
            }


            string genres = "";
            foreach (int item in ListBoxGenre.GetSelectedIndices())
            {
                genres += ListBoxGenre.Items[item] + ",";
            }
            genres = genres.Remove(genres.Length - 1);


            string filepath = "~/book_inventory/books1.png";
            string filename = Path.GetFileName(FileUpload.PostedFile.FileName);
            if (filename == "" || filename == null)
            {
                filepath = global_filepath;

            }
            else
            {
                FileUpload.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;
            }


            CLS_BookMaster book = new CLS_BookMaster()
            {
                book_id = TextBoxBookId.Text.Trim(),
                book_name = TextBoxBookName.Text.Trim(),
                no_of_page = TextBoxPage.Text.Trim(),
                language = DropDownListLanguage.SelectedItem.Value,

                author_name = DropDownListAuthorNames.SelectedItem.Value,
                publisher_name = DropDownListPublisher.SelectedItem.Value,
                publisher_date = TextBoxPublishDate.Text.Trim(),
                book_cost = TextBoxBookCost.Text.Trim(),
                book_description = TextBoxBookDescription.Text.Trim(),
                edition = TextBox1Edition.Text.Trim(),
                actual_stock = actual_stock.ToString(),
                current_stock = current_stock.ToString(),
                genre = genres,
                book_img_link = filepath


            };
            CMD_Book.UpdateBook(book);

        }
        void DeleteBook()
        {
            CLS_BookMaster book = new CLS_BookMaster()
            {
                book_id = TextBoxBookId.Text.Trim(),

            };

            CMD_Book.DeleteBook(book);
        }
        bool CheckBookExist()
        {

            List<CLS_BookMaster> books = CMD_Book.GetAllBooks().Where(c => c.book_id == TextBoxBookId.Text.Trim() || c.book_name == TextBoxBookName.Text.Trim()).ToList();
            if (books.Count >= 1)
            {
                return true;
            }
            return false;
        }
        void GetBookById()
        {
            List<CLS_BookMaster> book = CMD_Book.GetAllBooks().Where(c => c.book_id == TextBoxBookId.Text.Trim()).ToList();
            if (book.Count >= 1)
            {
                book.ForEach(c =>
                {
                    TextBoxBookId.Text = c.book_id;
                    TextBoxBookName.Text = c.book_name;
                    TextBoxBookCost.Text = c.book_cost;
                    TextBoxBookDescription.Text = c.book_description;
                    
                    TextBox1Edition.Text = c.edition;
                    TextBoxPage.Text = c.no_of_page;
                    DropDownListAuthorNames.SelectedValue = c.author_name;
                    DropDownListLanguage.SelectedValue = c.language;
                    DropDownListPublisher.SelectedValue = c.publisher_name;
                    TextBoxPublishDate.Text = c.publisher_date;

                    ListBoxGenre.ClearSelection();
                    string[] genre = c.genre.Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBoxGenre.Items.Count; j++)
                        {
                            if (ListBoxGenre.Items[j].ToString() == genre[i])
                            {
                                ListBoxGenre.Items[j].Selected = true;

                            }
                        }
                    }

                    TextBoxActualStock.Text = c.actual_stock;
                    TextBoxCurrentStock.Text = c.current_stock;

                    TextBoxIssuedBooks.Text = (int.Parse(TextBoxActualStock.Text) - int.Parse(TextBoxCurrentStock.Text)).ToString();

                    global_actual_stock = int.Parse(c.actual_stock);
                    global_current_stock = int.Parse(c.current_stock);
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = c.book_img_link;
                });
                
            }
            else
            {

            }
        }
    }
}