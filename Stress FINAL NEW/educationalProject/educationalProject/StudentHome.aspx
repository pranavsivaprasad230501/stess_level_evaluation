<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMasterpage.Master" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="educationalProject.StudentHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">

    var image1 = new Image()
    image1.src = "../img/slider/ed7.JPG"
    var image2 = new Image()
    image2.src = "../img/slider/ed8.JPG"
    var image3 = new Image()
    image3.src = "../img/slider/ed9.JPG"
                      
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">
    <!-- Start contact Area -->  
    <div id="about" class="about-area area-padding">
   <div class="container">
      <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
          <div class="section-headline text-center">
            <h2>Welcome to Student Home Page</h2>
          </div>
        </div>
      </div>
      <div class="row">
        <!-- single-well start-->
         <div id="Div1">
                <img src="../img/Edu_Banner5.JPG" width="1080px" height="320px" name="slide" />
                <script type="text/javascript">
            <!--
                    var step = 1
                    function slideit() {
                        document.images.slide.src = eval("image" + step + ".src")
                        if (step < 3)
                            step++
                        else
                            step = 1
                        setTimeout("slideit()", 2500)
                    }
                    slideit()
            //-->
                </script>
            </div>
     
      </div>
    </div>
    </div>
  <!-- End Contact Area -->


    </asp:Panel>
</asp:Content>
