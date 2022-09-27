import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import domtoimage from 'dom-to-image';
import  jsPDF from 'jspdf';
import { UserService } from 'src/app/Services/user.service';
@Component({
  selector: 'app-passport',
  templateUrl: './passport.component.html',
  styleUrls: ['./passport.component.css']
})
export class PassportComponent implements OnInit {
  
  constructor(public user:UserService,private router:Router) { }

  ngOnInit(): void {
    this.user.GetPassport(Number(localStorage.getItem('id')));

  }

  @ViewChild('pdfTable')
  pdfTable!: ElementRef;
  

  
  public downloadAsPDF2() {
    // const pdfTable = this.pdfTable.nativeElement;
    // var html = htmlToPdfmake(pdfTable.innerHTML);
    // const documentDefinition = { content: html };
    // pdfMake.createPdf(documentDefinition).download(); 
     
  }
  public downloadAsPDF() {
    let div = this.pdfTable.nativeElement;
   
    var img:any;
    var filename;
    var newImage:any;


    domtoimage.toPng(div, { bgcolor: '#fff' })

      .then(function(dataUrl) {

        img = new Image();
        img.src = dataUrl;
        newImage = img.src;

        img.onload = function(){

        var pdfWidth = img.width;
        var pdfHeight = img.height;

          // FileSaver.saveAs(dataUrl, 'my-pdfimage.png'); // Save as Image

          var doc;

          if(pdfWidth > pdfHeight)
          {
            doc = new jsPDF('l', 'px', [pdfWidth , pdfHeight]);
          }
          else
          {
            doc = new jsPDF('p', 'px', [pdfWidth , pdfHeight]);
          }


          var width = doc.internal.pageSize.getWidth();
          var height = doc.internal.pageSize.getHeight();


          doc.addImage(newImage, 'jpg',  10, 10, width, height);
          doc.addPage()
          filename = 'myPassport' + '.pdf';
          doc.save(filename);

        };


      })
      .catch(function(error) {

       // Error Handling

      });
 
  }

  BackToHome()
  {
    this.router.navigate(['']);
  }
}
