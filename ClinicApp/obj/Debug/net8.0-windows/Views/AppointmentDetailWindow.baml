   M S B A M L   `   `   `  ����  	ClinicApp-    'ClinicApp.Views.AppointmentDetailWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Appointment Detail��5   	   $	��400��6$   $	��400��61   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $
��Auto=�6$   .��5      �� $��10q�6   .+�5      �� $��16(�62   $
��Bold"�6@   $��0 0 0 10q�6R   ��6   �� *Name+6R   �� 5      $��Date：��6   $
��Bold"�6)   �� 5      $��0 0 0 5q�62   ��6   �� *Date+62   �� 5      $��Time：��6   $
��Bold"�6)   �� 5      $��0 0 0 5q�62   ��6   �� *Time+62   �� 5      $��	Reason：��6   $
��Bold"�6+   �� 5      $
��Wrap=�64   $��0 0 0 5q�6H   ��6   �� *Reason+6H   �� 5      $��Email：��6   $
��Bold"�6*   �� 5      $��0 0 0 5q�63   ��6   �� *Email+63   �� 5      $��Phone：��6   $
��Bold"�6*   �� 5      $��0 0 0 5q�63   ��6   �� *Phone+63   5      5      �� 5   
   $��1��6   $��10q�6"   .+�5       ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0,20,0,0q�6O   .+�5!      �� -   5         ��Name$ FindPatientButton��5!      $��Search Patient��5"      $	��138��5$      $
��10,0q�5%      �� 5'      -   5        $ ViewPatientButton��5'      $��View Patient��5(      $	��120��5*      $
��10,0q�5+      $y�	Collapsed=�5,      5-      5/      50      51      