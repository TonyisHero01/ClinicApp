   M S B A M L   `   `   `  ����   	ClinicApp!    ClinicApp.Views.PatientForm   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  Patient Information��$	��400��$	��400�� � WindowStartupLocation$ CenterScreen=�   MaterialDesignPaper#���   .��� $��20q� � RowDefinitions �� $��* ��� $
��Auto �.+��� $
��Auto=�.���� .+��� -    ��Name$ FullNameBox��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name�� % !MaterialDesignFloatingHintTextBox#��[ $
��0,10q��� -    ��Name$ 	GenderBox��$ Gender�� & "MaterialDesignFloatingHintComboBox#��[ $
��0,10q�.@��� $
��Male���� $��Female��(  "System.Windows.Controls.DatePicker  -     Name$ BirthDatePicker��$ 
Birth Date�� ( $MaterialDesignFloatingHintDatePicker#��[ $
��0,10q��� -   $ PhoneBox��$ Phone��#��[ $
��0,10q��� -   $ EmailBox��$ Email��#��[ $
��0,10q��� -   $ MedicalHistoryBox��$ Medical History��#��[ $
��0,10q� �� AcceptsReturn$
 True��$��80�� �� TextWrapping$
 Wrap=��� $��1��	 �� Orientation$	 
Horizontal=�$��Right=�$��0,20,0,0q�.+��� -   $
��Save��  MaterialDesignRaisedButton#��[ $��0,0,10,0q��� -   $��Cancel��   MaterialDesignOutlinedButton#��[ 