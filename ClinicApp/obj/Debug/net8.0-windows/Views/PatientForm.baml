   M S B A M L   `   `   `  ����  	ClinicApp!    ClinicApp.Views.PatientForm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Patient Information��5   	   $	��400��6%   $	��400��62    � WindowStartupLocation$ CenterScreen=�5   	      MaterialDesignPaper#���   5   	   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $
��Auto=�6   .��5      �� .+�5      �� -   5         ��Name$ FullNameBox��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name��5       % !MaterialDesignFloatingHintTextBox#��[ 5      $
��0,10q�5      �� 5      -   5         ��Name$ 	GenderBox��5      $ Gender��5       & "MaterialDesignFloatingHintComboBox#��[ 5      $
��0,10q�5      .@�5      �� $
��Male��6#   �� 5      $��Female��6#   5      (  "System.Windows.Controls.DatePicker  5      -   5          Name$ BirthDatePicker��5      $ 
Birth Date��5       ( $MaterialDesignFloatingHintDatePicker#��[ 5       $
��0,10q�5!      �� 5#      -   5        $ PhoneBox��5#      $ Phone��5$      #��[ 5%      $
��0,10q�5&      �� 5(      -   5        $ EmailBox��5(      $ Email��5)      #��[ 5*      $
��0,10q�5+      �� 5,      -   5        $ MedicalHistoryBox��5,      $ Medical History��5-      #��[ 5.      $
��0,10q�5/       �� AcceptsReturn$
 True��50      $��80��51       �� TextWrapping$
 Wrap=�52      54      55      �� 57   
   $��1��6   	 �� Orientation$	 
Horizontal=�58      $��Right=�59      $��0,20,0,0q�5:      .+�5;      �� -   5        $
��Save��5;        MaterialDesignRaisedButton#��[ 5<      $��0,0,10,0q�5>      �� 5?      -   5        $��Cancel��5?         MaterialDesignOutlinedButton#��[ 5@      5A      5B      5C      5D      