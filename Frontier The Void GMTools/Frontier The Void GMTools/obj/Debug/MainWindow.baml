   M S B A M L   `   `   `  ����T  PFrontier The Void GMTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Frontier_The_Void_GMToolsFrontier_The_Void_GMTools  5   	   *    $Frontier_The_Void_GMTools.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Frontier_The_Void_GMTools     5   	   X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4:
wpftoolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$"  Frontier: The Void - GMTools��5	   	   $	��700��6.   $
��1000��6;    � DataContext 5
   	   ��    Locator �� Source# [   �� Path$ vm_MainWindowViewModel�.��5      � .+�5   
   ]� .+�5      o� -   5         o�Name$
 menu��5      $	��Top=�6!   .@�5      m� $
��File��6   m� 5      $��Settings��6   .@�5      m� -   5        $��Unit Statistics��5      68   5      5       � 5      -   5          �Name$ frame��5      $��0,0,0,0q�6#   $��Stretch=�64   $��Stretch=�6R   5      5      #  Xceed.Wpf.Toolkit.ChildWindow  5   
   -   5          Name$ unitStatisticsChildWindow��5   !   $	��600��6D   $	��400��6P   .��5      ]� .+�5      ��  �� Orientation$ Vertical=�6   $
��Left=�64   .+�5      �� -   5         ��Name$+ %unitStatisticsChildWindow_unitListbox��5      $	��370��6z   $	��200��6�   ��6M   �� *UnitStatistics.Units+��5      �� 5      .R�5   "   �� $ Vertical=�6-   .+�5    &   �� -   5        $��	Add Above��5    -   $��20,5,0,0q�6A   $��70��6S   $
��Left=�6^   6y   �� 5"   &   $ 
Horizontal=�61   $��0,2,0,0q�6J   .+�5#   *   �� -   5        $��X��5#   1   $��5,0,0,0q�6=   6N   �� 5$   *   $��15,0,0,0q�6J   ��64   �� *Name+6J   5%   '   5&   #   5'      5)      5*      �� 5,      $ Vertical=�6   $��Right=�64   .+�5-      �� $ 
Horizontal=�6!   $��20,0,0,0q�6:   .+�5.      �� -   5        $��Make Default��5.   !   $��0,0,0,0q�68   6I   �� 5/      -	   5        $
��Save��5/   !   $��40��60   $��10,0,0,0q�6;   6M   �� 50      -
   5        $
��Load��50   !   $��40��60   $��10,0,0,0q�6;   6M   52      �� 54      $ Vertical=�6!   $��	20,20,0,0q�68    6K   �� 	 �� ElementName$+	 %unitStatisticsChildWindow_unitListbox��$ SelectedItem�.+�56      �� $ 
Horizontal=�6%   .+�57      �� $
��Name��6(   �� 58      -   5        
 ��Name$
 unitNameTextBox��58   &   $	��200��6U   $��5,0,0,0q�6a   ��6?   �� *Name+6a   59      �� 5:      $ 
Horizontal=�6%   .+�5;      �� $��Health��6(   �� 5<      -   5        $
 unitHealthTextBox��5<   &   $	��200��6Y   $��5,0,0,0q�6e   ��6A   �� *Health+6�   5=      �� 5>      $ 
Horizontal=�6%   .+�5?      �� $��Attack��6(   �� 5@      -   5        $
 unitAttackTextBox��5@   &   $	��200��6^   $��5,0,0,0q�6j   ��6A   �� *AttackPower+6�   5A      �� 5B      -   5         ��Name$ unitDetectedCheckBox��5B   #   $��Detected��6`    d� 	IsChecked 6A   �� *
Detected+6`   �� 5C      -   5        $% unitIsCommandAndControlCheckBox��5C   #   $��Command and Control��6v    6L   �� *IsCommandAndControl+6v   5D      5E      5F      5G      5I      5J      