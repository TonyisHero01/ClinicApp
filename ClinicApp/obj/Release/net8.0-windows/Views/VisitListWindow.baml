   M S B A M L   `   `   `  ����   	ClinicApp%    ClinicApp.Views.VisitListWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Visit records��$	��450��$	��700�� � WindowStartupLocation$ CenterScreen=�.��� $��20q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� -    ��Name$ 
HeaderText��$��0��$��20(�$
��Bold"�$��0,0,0,10q�$	��Top=��� $��1��$
��Auto=�.��&   System.Windows.Controls.DataGrid  -     Name$ VisitDataGrid��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��   SelectionMode$ Single=�   CanUserAddRows$ False��	   CanUserResizeRows$	 False��
   RowHeaderWidth$
 0Q�$	��200��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	VisitDate+ �� StringFormat$ 
yyyy-MM-dd��  $ Reason��$ *  �� *Reason+  $ 	Diagnosis��$ *  �� *	Diagnosis+  $ Doctor��$ *  �� *Doctor.Name+�� $��2�� �� Orientation$ 
Horizontal=�$��Right=�$��0,10,0,0q�.+��� -   $��Add new medical records��$	��219��$��0,0,10,0q��� -   $��Close��$��80��