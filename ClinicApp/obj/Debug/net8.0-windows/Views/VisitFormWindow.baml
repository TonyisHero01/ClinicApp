   M S B A M L   `   `   `  ����  	ClinicApp%    ClinicApp.Views.VisitFormWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  New medical records��5   	   $	��500��6%   $	��450��62    � WindowStartupLocation$ CenterScreen=�5   	      MaterialDesignPaper#���   5   	   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $
��Auto=�6   $��0��6:   .��5      �� .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ VisitDatePicker��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Date of visit��5       ( $MaterialDesignFloatingHintDatePicker#��[ 5      $
��0,10q�5      �� 5      -   5         ��Name$ 	ReasonBox��5      $ Reason of visit��5       % !MaterialDesignFloatingHintTextBox#��[ 5      $
��0,10q�5      �� 5      -   5        $ DiagnosisBox��5      $ 	Diagnosis��5      #��[ 5      $
��0,10q�5      �� 5       -   5        $ NotesBox��5       $ Notes��5!      #��[ 5"      $
��0,10q�5#      �� 5%      -   5         ��Name$ DoctorComboBox��5%      $ Doctor��5&       & "MaterialDesignFloatingHintComboBox#��[ 5'       �� DisplayMemberPath$
 Name��5(       �� SelectedValuePath$ Id��5)      $
��0,10q�5*      �� 5,      $��Prescribing Information��6   $��16(�5-      $
��Bold"�5.      $��0,20,0,5q�5/      �� 51      -   5        	 ��Name$	 PrescriptionList��51      ��52      �� 53      .R�54      �� 
 �� Orientation$
 
Horizontal=�6)   $	��0,5q�6B   .+�55   "   �� $��80��6*   $	��5,0q�65   $ 
Medication��6^   ��6B   �� *
Medication+6^   �� 56   "   $��60��6*   $	��5,0q�65   $ Dosage��6Z   ��6B   �� *Dosage+6Z   �� 57   "   $��60��6*   $	��5,0q�65   $ 	Frequency��6]   ��6B   �� *	Frequency+6]   �� 58   "   $��60��6*   $	��5,0q�65   $ Duration��6\   ��6B   �� *
Duration+6\   �� 59   "   $	��100��6*   $	��5,0q�66   $ Notes��6Z   ��6C   �� *Notes+6Z   �� 5:   "   -   5        $
��🗑��5:   )   $	��5,0q�66   
 � Tag 6d   �� 5;      5<      5>      �� 5@      -   5        $��Add Prescription��5@         MaterialDesignOutlinedButton#��[ 5A      $
��0,10q�5B      5C      �� 5E      $��Inspection Items��6   $��16(�5F      $
��Bold"�5G      $��0,20,0,5q�5H      �� 5J      -	   5        $	 TestList��5J      ��5K      �� 5L      .R�5M      �� $
 
Horizontal=�6)   $	��0,5q�6B   .+�5N   "   �� $	��100��6*   $	��5,0q�66   $ 	Test Name��6]   ��6C   �� *
TestName+6]   �� 5O   "   $��60��6*   $	��5,0q�65   $ Result��6Z   ��6B   �� *Result+6Z   �� 5P   "   $��60��6*   $	��5,0q�65   $
 Unit��6X   ��6B   �� *Unit+6X   �� 5Q   "   $��80��6*   $	��5,0q�65   $ 	Reference��6]   ��6B   �� *	Reference+6]     5R   "   $	��120��6-   $	��5,0q�69      SelectedDate 6F   �� *PerformedAt+�� 5S   "   -
   5        $
��🗑��5S   )   $	��5,0q�66    6\   �� 5T      5U      5W      �� 5Y      -   5        $��Adding Checks��5Y      #��[ 5Z   	   $
��0,10q�5[   	   5\   	   �� 5^      $��Attachment Information��6   $��16(�5_      $
��Bold"�5`      $��0,20,0,5q�5a      �� 5c      .+�5d      �� -   5        $��Upload Attachments��5d      #��[ 5e      $��0,0,0,10q�5g      �� 5i      -   5        $	 AttachmentList��5i   #   ��5j      �� 5k      .R�5l   "   �� $��5q�6F   ��6,   �� *
FilePath+6F   5m      5o      5p      5t      5u      �� 5w   
   $��1��6   $
 
Horizontal=�5x      $��Right=�5y      $��0,20,0,0q�5z      .+�5{      �� -   5        $
��Save��5{        MaterialDesignRaisedButton#��[ 5|      $��0,0,10,0q�5~      �� 5      -   5        $��Cancel��5      #��[ 5�      5�      5�      5�      5�      