   M S B A M L   `   `   `  ����  	ClinicApp%    ClinicApp.Views.PatientListView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5	      � $��20q�6     � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   $��0,0,0,15q�69   .+�5      �� $��Patient Management��6   $��24(�5      $
��Bold"�5      $��0,0,0,10q�5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ 	SearchBox��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search Name��5       %  !MaterialDesignFloatingHintTextBox#��[  5      $��0,0,0,10q�5      5      5      5      �� 5   
   $��1��6   $
��Auto=�6$   .��5       &   System.Windows.Controls.DataGrid  -   5           AutoGenerateColumns$ False��5"         SelectionMode$ Single=�5#         SelectionUnit$ FullRow=�5$         
IsReadOnly$
 True��5%         GridLinesVisibility$
 None=�5&      	   HeadersVisibility$	 Column=�5'      $��0,0,0,10q�5(      
   CanUserResizeRows$
 False��5)         CanUserAddRows$ False��5*         RowHeaderWidth$ 0Q�5+      $��0q�5,      
���������5       �� *
Patients+ �� SelectedItem 5!      �� *SelectedPatient+ �� Mode$ TwoWay=� � FocusVisualStyle 5-      Z�    RowStyle 51      �� 52       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�53      ��  �� Property � �� �� Value
 ���� 67   �� 54       � ��
 �   �67   �� 55       � ��$ 14(�65   �� 56       �@�FocusVisualStyle 6=   Z� �� 57       � ��$ 0q�6<    �� Triggers 59      ]� 5:       ]� 
Conditions 5;   "   �� 5<   &    �� Property �@J�IsMouseOver �� Value$
 True��6G   �� 5=   &    �@ 
IsSelected$ False��6F   ./�5?   "   ��  � �� �#eeeeee6?   5@      P� 5B       P� Property �@ 
IsSelected P� Value$
 True��6<   . �5C   "   ��  � �� �#2196F36?   �� 5D   "    � ��
 �����6?   5E      5G         	CellStyle 5J      �� 5K      *  $System.Windows.Controls.DataGridCell"  6   .�5L      ��  � ��
 ���� 67   �� 5M       � ��$ 0q�6<   �� 5N       �@�FocusVisualStyle 6=   Z� �� 5O       � ��$
 10,5q�64   �� 5P       � ��
 �   �67    5Q      P� 5R       �@ 
IsSelected$
 True��6H   . �5S   "   ��  � ��
 �����6?   5T      5V         Columns 5Y      0  *System.Windows.Controls.DataGridTextColumn  5Z      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
FullName+   ElementStyle 5[      �� 5\      " ��6$   .�5]   "   ��  � ��$ Center=�6F   �� 5^   "    � ��$
 Left=�6H   �� 5_   "    �@��Padding$
 10,0q�6<   5`      5b        5d      $ Gender��6)   $ * 6T    69   �� *Gender+ 5e      �� 5f      " ��6$   .�5g   "   ��  � ��$ Center=�6F   �� 5h   "    � ��$
 Left=�6H   �� 5i   "    �@��Padding$
 10,0q�6<   5j      5l        5n      $ 
Birth Date��6)   $ * 6t    6=   �� *	BirthDate+  �� StringFormat$  
yyyy-MM-dd�� 5o      �� 5p      " ��6$   .�5q   "   ��  � ��$ Center=�6F   �� 5r   "    � ��$
 Left=�6H   �� 5s   "    �@��Padding$
 10,0q�6<   5t      5v        5x      $ Phone��6)   $ * 6R    68   �� *Phone+ 5y      �� 5z      " ��6$   .�5{   "   ��  � ��$ Center=�6F   �� 5|   "    � ��$
 Left=�6H   �� 5}   "    �@��Padding$
 10,0q�6<   5~      5�      5�      5�      ]� 5�   
   $��2��6   $��Right=�6!   $��0,10,0,0q�6=   .+�5�      �� -   5        $	��Add��5�      $��80��6#   $��5q�6.   69   �� 5�      -   5        $
��Edit��5�      $��80��6$   $��5q�6/   6:   �� 5�      -   5        $��Delete��5�      $��80��6&   $��5q�61   6<   5�      5�      5�      