   M S B A M L   `   `   `  ����  	ClinicApp.    (ClinicApp.Views.SetUnavailableTimeWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$"  Set unavailable time periods��5   	   $	��350��5   	   $	��400��6    � WindowStartupLocation$ CenterOwner=�5   	   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Start Date: ��6   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ StartDatePicker��5      $��0��6.   $��
100,0,0,10q�6;   �� 5   
   $��1��6   $��
Start Time��6   �� 5   
   -   5         ��Name$ StartTimeBox��5      $��1��6(   $��
100,0,0,10q�65   $��09:00��6I   �� 5   
   $��2��6   $��
End Date: ��6     5   
   -   5        $ EndDatePicker��5      $��2��6,   $��
100,0,0,10q�69   �� 5   
   $��3��6   $��
End Time: ��6   �� 5   
   -   5        $ 
EndTimeBox��5      $��3��6&   $��
100,0,0,10q�63   $��11:00��6G   �� 5   
   $��4��6   $��Note: ��6   �� 5   
   -   5        $ NoteBox��5      $��4��6#   $��
100,0,0,10q�60   �� 5    
   -   5        $��5��5       $
��Save��6   $��Right=�6-   $��80��6I   $��0,20,0,0q�5!   *   5"      5#      