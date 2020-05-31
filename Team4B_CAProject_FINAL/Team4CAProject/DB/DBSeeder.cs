using Team4CAProject.Models;

namespace Team4CAProject.DB
{
    public class DBSeeder
    {
        public DBSeeder (CADb dbcontext)
        {
            dbcontext.Customers.Add(new Customer("saw", "password1"));
            dbcontext.Customers.Add(new Customer("lance", "password2"));
            dbcontext.Customers.Add(new Customer("summer", "password3"));
            dbcontext.Customers.Add(new Customer("lirang", "password4"));

            dbcontext.Products.Add(new Product("Sage 50", "Quantum version 2020 remote installation and problem solving. Make Enquiry. Professional Services.",
                100, 60, "img1.jpg"));
            
            dbcontext.Products.Add(new Product("H&R Block", "Get H&R Block software support for your tax return. Contact us now for more information !",
               100, 70, "img3.jpg"));
            
            dbcontext.Products.Add(new Product("Design CAD", "CAD Designers use technology to help generate designs for complex projects. ",
               100, 89, "img4.jpg"));
            
            dbcontext.Products.Add(new Product("Turbotax", "TurboTax® Helps You Get Your Maximum Refund Guaranteed. File Your Taxes Free Now! Tax Filing Is Fast And Simple With TurboTax®.",
               100, 99, "img5.jpg"));
            
            dbcontext.Products.Add(new Product("Expert PDF Converter 12", "eXpert PDF 12 Converter is the PDF solution that offers everything you need to open, create and convert your PDF files.",
               100, 110, "img6.jpg"));                       
            
            dbcontext.Products.Add(new Product("Movavi Photo Editor for Mac 5 Personal", "Cover up and eliminate any facial blemishes and remove unnecessary objects or background through special effects.",
                100, 130, "Photo.jpeg"));

            dbcontext.Products.Add(new Product("Adobe Photoshop Elements 2020 & Premiere Elements 2020", "Gain access to Adobe latest sensei AI technology to add a personal touch to your pictures.",
                100, 159, "AdobePhotoshop.jpg"));

            dbcontext.Products.Add(new Product("Luminar 4 Photo Editing Software", "Access special features in the software to enhance your pictures.",
                100, 190, "Luminar.jpg"));

            dbcontext.Products.Add(new Product("Aurora HDR-HDR Image Enhancing Program", "Access special features in the software to enhance your pictures.",
                100, 299, "Aurora.jpg"));






            dbcontext.SaveChanges();


        }
    }
}
