   M S B A M L   `   `   `  ���� D  @ClinicApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ClinicApp.ConvertersClinicApp.Converters  '    !ClinicApp.Views.VisitDetailWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     9
converters"clr-namespace:ClinicApp.Converters       � Title$  Visit Detail��$	��500��$	��600�� � WindowStartupLocation$ CenterScreen=� � 	Resources ,   &ClinicApp.Converters.FileNameConverter   FileNameConverter��%   &	          .���� .���� $��20q�.+��� $��Visit Detail��$��22(�$
��Bold"�$��0,0,0,10q��� -    ��Name$ DateText��$��14(�$	��0,5q��� -   $ 
DoctorText��$��14(�$	��0,5q��� -   $ 
ReasonText��$��14(�$	��0,5q��� -   $ DiagnosisText��$��14(�$	��0,5q��� -   $ 	NotesText��$��14(�$	��0,5q��� $��Diagnostic Statistics��$��16(�$
��Bold"�$��0,20,0,5q��� -   $ DiagnosisStatsText��$��14(�$
��Wrap=��� $��Prescription��$��16(�$
��Bold"�$��0,20,0,5q��� -    ��Name$ PrescriptionList������ .R��� $	��0,2q����� �� $��Medical Test��$��16(�$
��Bold"�$��0,20,0,5q��� -   $ TestList������ .R��� $	��0,2q����� �� $��Attachments��$��16(�$
��Bold"�$��0,20,0,5q��� -	    ��Name$ AttachmentList������ .R��� $	��0,2q����� *
FilePath+ �� 	Converter# [  �� -
   $
��Edit��$	��100��$��0,0,10,0q��� -   $��Export As PDF��$	��137��$��	0,10,10,0q��� -   $��Send to Email��$	��162��$��	0,10,10,0q��� -   $��Close��$	��100��$��Right=�$��0,20,0,0q�