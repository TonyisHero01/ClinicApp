   M S B A M L   `   `   `  ����   	ClinicApp%    ClinicApp.Views.PatientListView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� $��20q�  � RowDefinitions  �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0�� �� Orientation$ Vertical=�$��0,0,0,15q�.+��� $��Patient Management��$��24(�$
��Bold"�$��0,0,0,10q��� $ 
Horizontal=�.+��� -    ��Name$ 	SearchBox��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search Name�� %  !MaterialDesignFloatingHintTextBox#��[  $��0,0,0,10q��� $��1��$
��Auto=�.��&   System.Windows.Controls.DataGrid  -      AutoGenerateColumns$ False��   SelectionMode$ Single=�   SelectionUnit$ FullRow=�   
IsReadOnly$
 True��   GridLinesVisibility$
 None=�	   HeadersVisibility$	 Column=�$��0,0,0,10q�
   CanUserResizeRows$
 False��   CanUserAddRows$ False��   RowHeaderWidth$ 0Q�$��0q�
����������� *
Patients+ �� SelectedItem �� *SelectedPatient+ �� Mode$ TwoWay=� � FocusVisualStyle Z�    RowStyle ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"  .���  �� Property � �� �� Value
 ���� ��  � ��
 �   ���  � ��$ 14(���  �@�FocusVisualStyle Z� ��  � ��$ 0q� �� Triggers ]�  ]� 
Conditions ��  �� Property �@J�IsMouseOver �� Value$
 True����  �@ 
IsSelected$ False��./���  � �� �#eeeeeeP�  P� Property �@ 
IsSelected P� Value$
 True��. ���  � �� �#2196F3��  � ��
 �����   	CellStyle �� *  $System.Windows.Controls.DataGridCell"  .���  � ��
 ���� ��  � ��$ 0q���  �@�FocusVisualStyle Z� ��  � ��$
 10,5q���  � ��
 �   � P�  �@ 
IsSelected$
 True��. ���  � ��
 �����   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
FullName+   ElementStyle �� " ��.���  � ��$ Center=���  � ��$
 Left=���  �@��Padding$
 10,0q�  $ Gender��$ *  �� *Gender+ �� " ��.���  � ��$ Center=���  � ��$
 Left=���  �@��Padding$
 10,0q�  $ 
Birth Date��$ *  �� *	BirthDate+  �� StringFormat$  
yyyy-MM-dd�� �� " ��.���  � ��$ Center=���  � ��$
 Left=���  �@��Padding$
 10,0q�  $ Phone��$ *  �� *Phone+ �� " ��.���  � ��$ Center=���  � ��$
 Left=���  �@��Padding$
 10,0q�]� $��2��$��Right=�$��0,10,0,0q�.+��� -   $	��Add��$��80��$��5q��� -   $
��Edit��$��80��$��5q��� -   $��Delete��$��80��$��5q�