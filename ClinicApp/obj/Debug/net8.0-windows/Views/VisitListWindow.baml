   M S B A M L   `   `   `  ����  	ClinicApp%    ClinicApp.Views.VisitListWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Visit records��5   	   $	��450��6   $	��700��6,    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ 
HeaderText��5      $��0��5      $��20(�5      $
��Bold"�5      $��0,0,0,10q�5      $	��Top=�5      �� 5   
   $��1��6   $
��Auto=�5      .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ VisitDataGrid��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5         SelectionMode$ Single=�5         CanUserAddRows$ False��5      	   CanUserResizeRows$	 False��5      
   RowHeaderWidth$
 0Q�5      $	��200��5         Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6n   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *	VisitDate+ �� StringFormat$ 
yyyy-MM-dd��6n     5"      $ Reason��6)   $ * 6T    69   �� *Reason+6T     5#      $ 	Diagnosis��6)   $ * 6Z    6<   �� *	Diagnosis+6Z     5$      $ Doctor��6)   $ * 6Y    69   �� *Doctor.Name+6Y   5&      5'      �� 5)   
   $��2��6    �� Orientation$ 
Horizontal=�5*      $��Right=�5+      $��0,10,0,0q�5,      .+�5-      �� -   5        $��Add new medical records��5-      $	��219��5.      $��0,0,10,0q�5/      50      �� 51      -   5        $��Close��51      $��80��52      53      54      55      56      