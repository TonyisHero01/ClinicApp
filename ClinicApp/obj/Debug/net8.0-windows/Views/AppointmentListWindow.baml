   M S B A M L   `   `   `  ����D  @ClinicApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ClinicApp.ConvertersClinicApp.Converters  5   	   +    %ClinicApp.Views.AppointmentListWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   3conv"clr-namespace:ClinicApp.Converters     5   	     � Title$  Reservation List��5   	   $	��400��5   	   $	��600��6    � WindowStartupLocation$ CenterOwner=�5   	    � SizeToContent$ Manual=�5   	    � 
ResizeMode$ 	CanResize=�5	   	    � 	Resources 5      1   +ClinicApp.Converters.HandledToTextConverter   HandledToTextConverter-   'ClinicApp.Converters.RowHeightConverter  RowHeightConverter,   &ClinicApp.Converters.FontSizeConverter  FontSizeConverter��%W   &	        &	      &	 &       5   
   6&     5   
   6"     5   
   6!   5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ AppointmentGrid��5      $��0��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5      	   CanUserAddRows$	 False��5      
   SelectionMode$
 Single=�5         HeadersVisibility$ Column=�5!      $��Disabled=�5$      $��Disabled=�5%      ��5      ��    	RowHeight 5"      �� *ActualHeight+ �� ElementName$ AppointmentGrid�� �� 	Converter# [ ��5#      �� *ActualHeight+$ AppointmentGrid��# [    RowStyle 5&      �� 5'       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    �� Triggers 5(      �� 5)       �� Binding 6&   �� *
Notified+ �� Value	 False6C   .a�5*      ��  �� Property � �� �� Value �#FFFFE06;   5+      5-         Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6H   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 61   �� *Id+6H     52      $
 Name��6%   $ * 6L    63   �� *Name+6L     53      $ Email��6%   $ 2* 6N    64   �� *Email+6N     54      $ Phone��6%   $
 1.5* 6N    64   �� *Phone+6N     55      $
 Date��6%   $ 2* 6L    63   �� *Date+6L     56      $
 Time��6%   $ 1* 6L    63   �� *Time+6L     57      $ Reason��6%   $ 2* 6P    65   �� *Reason+6P   4
  .System.Windows.Controls.DataGridTemplateColumn
  58      $ 
Is Handled��6)   $ 1* 6=    
  CellTemplate 59      �� 5:      .R�5;      �� $��Center=�5<   (   $
��Bold"�5=   (   ��5;   (   �� *	Handled+# [  ��5>   "   �� 5?   &   " ��6,    5@   *   �� 5A   .    6:   �� *	Handled+ True6V   .a�5B   2   ��  � ��
 � � �6O   5C   /   �� 5D   .    6:   �� *	Handled+	 False6V   .a�5E   2   ��  � ��
 �  ��6O   5F   /   5H   '   5J      5K      5M      5O      � 5Q   
   $��1��6   $��0,10,0,0q�6    � ColumnDefinitions 5R      �� 5S      $��* �6#   �� 5T      $
��Auto �6#   .+�5W      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5X      �� -   5        $��Previous��5X      $
��10,0q�6G   $
��15,4q�6U   �� 5Y      -   5         ��Name$ PageInfoText��5Y      $��Center=�5Z      $
��Bold"�5[      $
��10,0q�5\      $��1��5]      �� 5^      -   5        $
��Next��5^      $
��10,0q�6?   $
��15,4q�6M   5_      �� 5a      -   5        $��1��5a      $��Set unavailable time��5b      $��20,0,0,0q�5d      $
��15,4q�5e      $��Center=�5f      $��Right=�5g      5h      5j      5k      