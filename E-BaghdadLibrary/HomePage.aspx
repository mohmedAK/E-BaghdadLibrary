<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ELibrary.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script>
        //document.onreadystatechange = function () {
        //    var state = document.readyState
        //    if (state == 'interactive') {
        //        document.getElementById('contents').style.visibility = "hidden";
        //    } else if(state =='complete') {
        //        setTimeout(function () 



        //            document.getElementById('interactive');
        //            document.getElementById('load').style.visibility = "hidden";
        //            document.getElementById('contents').style.visibility = "visible";
        //        }, 3000);
        //    }
        //}
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <div id="load"></div>--%>

    <div id="contents">
        <%-- <section>
                <img src="imgs/home-bg.jpg"  class="img-fluid"/>
            </section>--%>
        <%-- Start Scroll --%>
        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
            <ol class="carousel-indicators">
                <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>

            </ol>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="imgs/home-bg.jpg" class="d-block w-100" alt="...">
                </div>
                <div class="carousel-item">
                    <img src="imgs/in-homepage-banner.jpg" class="d-block w-100" alt="...">
                </div>

            </div>
            <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
        <%-- end Scroll --%>

        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                            <h2><b><font color="Brown"> Our Feature</font></b></h2>
                        <p><b>Our 3 primary Feature</b></p>
                        </center>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <center>
                        <div class="zoom-effect-container">
                            <a href="viewBooks.aspx">
                                <img width="150px" src="imgs/digital-inventory.png"/>
                            </a>
                             
                        </div>
                            
                          <h4>Digital Book Inventory</h4>
                          <p class="text-center">The site contains a store for the books inside the library</p>
                        </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <div  class="zoom-effect-container">
                            <a href="viewBooks.aspx">
                                 <img width="150px"  src="imgs/search-online.png"/>
                            </a>                         
                        </div>
                          
                          <h4>Search Books</h4>
                          <p class="text-center">The ability to search for any information about books from a writer, publisher, or the language of the book, etc.</p>
                       </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <div  class="zoom-effect-container">
                            <a href="UserLogin.aspx">
                                <img width="150px" src="imgs/defaulters-list.png"/>
                            </a>
                          

                        </div>
                          <h4>Defaulter List</h4>
                          <p class="text-center">The site has a list of book tenants as well as book defaulters</p>
                       </center>
                </div>
            </div>
        </div>


        <%-- Start Scroll --%>
        <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="slide_iamge/s1.jpg" class="d-block w-100" alt="...">
                   
                </div>
                <div class="carousel-item">
                    <img src="slide_iamge/s2.jpg" class="d-block w-100" alt="...">
                    
                </div>
                <div class="carousel-item">
                    <img src="slide_iamge/s3.jpg" class="d-block w-100" alt="...">
                   
                </div>
                <div class="carousel-item">
                    <img src="slide_iamge/s4.jpg" class="d-block w-100" alt="...">
                   
                </div>

            </div>
            <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>


        <%-- end Scroll --%>

        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                             <h2><b><font color="Brown"> Our Feature</font></b></h2>
                        <p><b>Our 3 primary Feature</b></p>
                        </center>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <center>
                     <div  class="zoom-effect-container">
                          <a href="userSignUp.aspx">
                              <img width="150px" src="imgs/sign-up.png" />
                          </a> 
                         </div>
                           <h4>Sign Up</h4>
                          <p class="text-center">The possibility of membership registration inside the library and the possibility of modifying the information and displaying the rented books</p>
                        </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <div  class="zoom-effect-container">
                            <a href="UserLogin.aspx">
                                 <img width="150px"  src="imgs/book-online.png"/> 
                            </a>
                            
                        </div>
                          
                           <h4>Member Status</h4>
                           <p class="text-center">The possibility of limiting or suspending membership, as well as activating it by the admin, and membership will be suspended temporarily in the event that the information is modified for the purpose of viewing the amendments.</p>
                       </center>
                </div>
                <div class="col-md-4">
                    <center>
                           <div  class="zoom-effect-container">
                               <a href="https://www.facebook.com/">
                                    <img width="150px" src="imgs/library.png" />
                               </a>
                               
                           </div>
                          
                             <h4>Visit Us</h4>
                           <p class="text-center">You can contact us through the library website, as well as through social media or through the feedback page</p>
                       </center>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
