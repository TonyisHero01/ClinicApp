   M S B A M L   `   `   `  ����   	ClinicApp%    ClinicApp.Views.VisitFormWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  New medical records��$	��500��$	��450�� � WindowStartupLocation$ CenterScreen=�   MaterialDesignPaper#���   .��� $��20q� � RowDefinitions �� $��* ��� $
��Auto �.+��� $
��Auto=�$��0��.���� .+�(  "System.Windows.Controls.DatePicker  -     Name$ VisitDatePicker��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Date of visit�� ( $MaterialDesignFloatingHintDatePicker#��[ $
��0,10q��� -    ��Name$ 	ReasonBox��$ Reason of visit�� % !MaterialDesignFloatingHintTextBox#��[ $
��0,10q��� -   $ DiagnosisBox��$ 	Diagnosis��#��[ $
��0,10q��� -   $ NotesBox��$ Notes��#��[ $
��0,10q��� -    ��Name$ DoctorComboBox��$ Doctor�� & "MaterialDesignFloatingHintComboBox#��[  �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id��$
��0,10q��� $��Prescribing Information��$��16(�$
��Bold"�$��0,20,0,5q��� -   	 ��Name$	 PrescriptionList������ .R��� 
 �� Orientation$
 
Horizontal=�$	��0,5q�.+��� $��80��$	��5,0q�$ 
Medication������ *
Medication+�� $��60��$	��5,0q�$ Dosage������ *Dosage+�� $��60��$	��5,0q�$ 	Frequency������ *	Frequency+�� $��60��$	��5,0q�$ Duration������ *
Duration+�� $	��100��$	��5,0q�$ Notes������ *Notes+�� -   $
��🗑��$	��5,0q�
 � Tag �� �� -   $��Add Prescription��   MaterialDesignOutlinedButton#��[ $
��0,10q��� $��Inspection Items��$��16(�$
��Bold"�$��0,20,0,5q��� -	   $	 TestList������ .R��� $
 
Horizontal=�$	��0,5q�.+��� $	��100��$	��5,0q�$ 	Test Name������ *
TestName+�� $��60��$	��5,0q�$ Result������ *Result+�� $��60��$	��5,0q�$
 Unit������ *Unit+�� $��80��$	��5,0q�$ 	Reference������ *	Reference+  $	��120��$	��5,0q�   SelectedDate �� *PerformedAt+�� -
   $
��🗑��$	��5,0q� �� �� -   $��Adding Checks��#��[ $
��0,10q��� $��Attachment Information��$��16(�$
��Bold"�$��0,20,0,5q��� .+��� -   $��Upload Attachments��#��[ $��0,0,0,10q��� -   $	 AttachmentList������ .R��� $��5q����� *
FilePath+�� $��1��$
 
Horizontal=�$��Right=�$��0,20,0,0q�.+��� -   $
��Save��  MaterialDesignRaisedButton#��[ $��0,0,10,0q��� -   $��Cancel��#��[ 