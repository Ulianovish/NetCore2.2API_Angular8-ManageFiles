import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BairesDevComponent } from './baires-dev/baires-dev.component';
import { BairesDevService } from './services/baires-dev.service';

@NgModule({
  declarations: [
    AppComponent,
    BairesDevComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    BairesDevService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
