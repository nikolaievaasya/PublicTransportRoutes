   M S B A M L   `   `   `  ���� P  LPublicTransportRoutes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:PublicTransportRoutes.ViewPublicTransportRoutes.View  O,clr-namespace:PublicTransportRoutes.ControlsPublicTransportRoutes.Controls  +    %PublicTransportRoutes.View.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:PublicTransportRoutes.View     =ctls,clr-namespace:PublicTransportRoutes.Controls     $	��450��$	��800��  � WindowStyle$
  None=� � 
ResizeMode$ NoResize=�
������  � AllowsTransparency$
 True�� � Title$  PTR - Public Trafic Routes��.����    FourthColor#��[   �� CornerRadius$ 5��  
FirstColor#��[ $��2q�._��  � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��0�����#D5B4B4$ 5,0,0,5���� $��0��  SecondColor#��[ $ 8 0 0 8��._�� -    �Name$ GridNav��$��60�� � RowDefinitions �� $��60 ��� $��* �.+�� $��0��.+��� $��5 0 0 0q�$��50��$��40��$
��Left=�����  �� ImageSource$ /Resources/Logo.png��	 j� Stretch$	 Uniform=��� -   
 ��Name$
 NamingTitle��$��Public Transport Routes��#��[ $��Bahnschrift Condensed)�$��16(�$��Center=�$
��Left=�$��60 0 0 0q��� $��1��$��
-1 40 0 20q�.+��� -    ��Name$ btnHome��  PopupButtonStyle#���  ���� *NavigateToHomeView+.��-   'PublicTransportRoutes.Controls.MenuItem     	GroupName$ MenuItem��   IndicatorBrush# [   home   Icon# �     	IconWidth$ 16��   Text$
 HOME��$��Center=��� -   $ btnAdd��#���  ���� *NavigateToAddView+.��  $ MenuItem��# [   add# �  $ 16��$	 ADD��$��Center=��� -   $ 	btnSearch��#���  ���� *NavigateToSearchView+.��  $ MenuItem��# [  
 search# �  $ 16��$ SEARCH��$��Center=�� -    �Name$ Popup�� � AllowsTransparency$
 True�� � HorizontalOffset$ 0�� � VerticalOffset$ 10��.��.   (PublicTransportRoutes.Controls.UserPopup  -     Name$ Header��#��[ � $��1�� �� $��50 ��� $��* �.+�d� -    d�Name$ Tg_Btn��$��1��$��Center=�  iToggleButtonStyle#���  $
��Left=�$��0q�
������ $��
10,15,0,15q�$��30��$��30�� d� 	IsChecked �� *IsToogleButtonActive+ � Triggers :�  :� RoutedEvent$ ToggleButton.Unchecked��.[��� .���� -	    ��Name$ HideStackPanel��.��W�  �� 
TargetName$ GridNav�� �� TargetProperty$ Width� g� 	BeginTime	 0:0:0 W� From 210	 W� To 60  g� Duration$  0:0:0.5D�:� $ ToggleButton.Checked��.[��� .���� -
   $ ShowStackPanel��.��W� $ GridNav��$ Width�	 0:0:0 60 210$  0:0:0.5D��� $��0��$��Right=�$	��Top=�$��0,5,10,0q�$��30��! �� Orientation$! 
Horizontal=�$��RightToLeft=�$��2��.+��� -   $ btnClose��  IconButtonsStyle#��[  		 close#��� 	 
" � Tag$" IsCloseButton���� -   $ btnMinimize��#���   
 minimize#��� 
 �� $��1��$��10q����� *NavigationService.CurrentView+