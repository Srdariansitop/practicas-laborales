#!/bin/bash

#Una funcion para abir el proyecto

run(){
script_dir = $(dirname "$0")
project_path = "$script_dir/MoogleEngineDarian.cs"
code $project_path
                }

#Funcion para compilar y generar archivo PDF de laTEX (Informe)
report(){
script_dir = $(dirname "$O")
pdf_file = "Moogle Informe.pdf"
pdflatex "$script_dir/$pdf_file"
         }

#Funcion para compilar y generar archivo PDF de laTEX (Presentacion)
slides(){
script_dir = $(dirname "$O")
pdf_file2 = "Moogle Presentacion.pdf"
pdflatex "$script_dir/$pdf_file2"
         }

#Funcion para abrir archivo PDF de laTEX (Informe )

show_report(){
current_dir = "$PWD"
pdf_file = "Moogle Informe.pdf"
xdg-open "$current_dir/$pdf_file"
          }

#Funcion para abrir archivo PDF de laTEX (Presentacion)

show_slides(){
current_DIRR = "$PWD"
pdf2_file = "Moogle Presentacion.pdf"
xdg-open "current_DIRR/$pdf2_file"
        }

#Funcion para eliminar los archivos auxiliares de laTEX que generan los pdfs
clean(){
rm -f   *.aux *.log *.out *.toc *.gz

        }
