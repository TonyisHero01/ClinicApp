   M S B A M L   `   `   `  ���� D  @ClinicApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ClinicApp.ConvertersClinicApp.Converters  +    %ClinicApp.Views.AppointmentListWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     3conv"clr-namespace:ClinicApp.Converters       � Title$  Reservation List��$	��400��$	��600�� � WindowStartupLocation$ CenterOwner=� � SizeToContent$ Manual=� � 
ResizeMode$ 	CanResize=� � 	Resources 1   +ClinicApp.Converters.HandledToTextConverter   HandledToTextConverter-   'ClinicApp.Converters.RowHeightConverter  RowHeightConverter,   &ClinicApp.Converters.FontSizeConverter  FontSizeConverter��%-   &	        &	      &	 
           .��� $��10q� � RowDefinitions �� $��* ��� $
��Auto �.+�&   System.Windows.Controls.DataGrid  -     Name$ AppointmentGrid��$��0��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��	   CanUserAddRows$	 False��
   SelectionMode$
 Single=�   HeadersVisibility$ Column=�$��Disabled=�$��Disabled=�����    	RowHeight �� *ActualHeight+ �� ElementName$ AppointmentGrid�� �� 	Converter# [ ���� *ActualHeight+$ AppointmentGrid��# [    RowStyle ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"   �� Triggers ��  �� Binding �� *
Notified+ �� Value	 False.a���  �� Property � �� �� Value �#FFFFE0   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *Id+  $
 Name��$ *  �� *Name+  $ Email��$ 2*  �� *Email+  $ Phone��$
 1.5*  �� *Phone+  $
 Date��$ 2*  �� *Date+  $
 Time��$ 1*  �� *Time+  $ Reason��$ 2*  �� *Reason+4
  .System.Windows.Controls.DataGridTemplateColumn
  $ 
Is Handled��$ 1*  
  CellTemplate �� .R��� $��Center=�$
��Bold"����� *	Handled+# [  ���� " �� ��  �� *	Handled+ True.a���  � ��
 � � ���  �� *	Handled+	 False.a���  � ��
 �  ��� $��1��$��0,10,0,0q� � ColumnDefinitions �� $��* ��� $
��Auto �.+���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $��Previous��$
��10,0q�$
��15,4q��� -    ��Name$ PageInfoText��$��Center=�$
��Bold"�$
��10,0q�$��1���� -   $
��Next��$
��10,0q�$
��15,4q��� -   $��1��$��Set unavailable time��$��20,0,0,0q�$
��15,4q�$��Center=�$��Right=�