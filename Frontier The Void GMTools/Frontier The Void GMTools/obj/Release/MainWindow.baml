   M S B A M L   `   `   `  ���� T  PFrontier The Void GMTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Frontier_The_Void_GMToolsFrontier_The_Void_GMTools  *    $Frontier_The_Void_GMTools.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:Frontier_The_Void_GMTools     X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4:
wpftoolkit)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$"  Frontier: The Void - GMTools��$	��700��$
��1000�� � DataContext ��    Locator �� Source# [   �� Path$ vm_MainWindowViewModel�.��� .+�]� .+�o� -    o�Name$
 menu��$	��Top=�.@�m� $
��File��m� $��Settings��.@�m� -   $��Unit Statistics�� � -     �Name$ frame��$��0,0,0,0q�$��Stretch=�$��Stretch=�#  Xceed.Wpf.Toolkit.ChildWindow  -     Name$ unitStatisticsChildWindow��$	��600��$	��400��.��]� .+���  �� Orientation$ Vertical=�$
��Left=�.+��� -    ��Name$+ %unitStatisticsChildWindow_unitListbox��$	��370��$	��200������ *UnitStatistics.Units+���� .R��� $ Vertical=�.+��� -   $��	Add Above��$��20,5,0,0q�$��70��$
��Left=��� $ 
Horizontal=�$��0,2,0,0q�.+��� -   $��X��$��5,0,0,0q��� $��15,0,0,0q����� *Name+�� $ Vertical=�$��Right=�.+��� $ 
Horizontal=�$��20,0,0,0q�.+��� -   $��Make Default��$��0,0,0,0q��� -	   $
��Save��$��40��$��10,0,0,0q��� -
   $
��Load��$��40��$��10,0,0,0q��� $ Vertical=�$��	20,20,0,0q� �� 	 �� ElementName$+	 %unitStatisticsChildWindow_unitListbox��$ SelectedItem�.+��� $ 
Horizontal=�.+��� $
��Name���� -   
 ��Name$
 unitNameTextBox��$	��200��$��5,0,0,0q����� *Name+�� $ 
Horizontal=�.+��� $��Health���� -   $
 unitHealthTextBox��$	��200��$��5,0,0,0q����� *Health+�� $ 
Horizontal=�.+��� $��Attack���� -   $
 unitAttackTextBox��$	��200��$��5,0,0,0q����� *AttackPower+�� -    ��Name$ unitDetectedCheckBox��$��Detected�� d� 	IsChecked �� *
Detected+�� -   $% unitIsCommandAndControlCheckBox��$��Command and Control�� �� *IsCommandAndControl+