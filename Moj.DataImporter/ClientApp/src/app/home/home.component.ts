import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { DataImporterService } from '../services/data-importer.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import Swal from 'sweetalert2/dist/sweetalert2.js';

import {MatTableDataSource} from '@angular/material/table';
import { OrderDto } from '../models/OrderDto.model';
import { MatPaginator } from '@angular/material/paginator';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit {
  excelFile: any;

  progress = 0;
  loading = false;
  done = false;
  dataSource = new MatTableDataSource<OrderDto>([]);
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  form: FormGroup;

  displayedColumns = ['id', 'key', 'itemCode', 'colorCode', 'description', 'price', 'discountPrice', 'deliverdIn', 'q1', 'size', 'color'];

  constructor(private dataImporter: DataImporterService,private fb: FormBuilder,private cdr: ChangeDetectorRef) {}

  ngOnInit() {

    this.form = this.fb.group({

      datafile: [null, Validators.required],

    });
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
  selectFile(file) {
    this.excelFile = file.target.files[0];

  }

  sendFile() {

    if (this.form.invalid) {
      return;
    }
    console.log(this.form.value, this.excelFile);
    this.loading = true;
    this.dataImporter.uploadFile(this.excelFile).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * event.loaded / event.total);
       } else if (event instanceof HttpResponse) {
        if (event.ok) {
          console.log(event.body);
          this.dataSource.data = event.body;
          this.done = true;
          this.cdr.detectChanges();
          this.dataSource.paginator = this.paginator;

        } else {

        }
        this.progress = 0;
        this.loading = false;
      }
    }, error => {
      this.progress = 0;
      this.loading = false;
      Swal.fire({titleText: 'An Error occurred please try again', text: 'Message: ' + error.error, icon: 'error'});

      console.log(error);
    });
  }
  back() {
    this.done = false;
    this.excelFile = null;
    this.form.controls['datafile'].setValue(null);
  }
}
