   M S B A M L   `   `   `  ���� T  PFrontier The Void GMTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Frontier_The_Void_GMToolsFrontier_The_Void_GMTools  7    1Frontier_The_Void_GMTools.FTLPlanetGenerationPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9local'clr-namespace:Frontier_The_Void_GMTools       N� 
Background
  ����� N� Title$ FTL and Planet Generation�� � DataContext ��    Locator �� Source# [   �� Path$% vm_FTLPlanetGenerationViewModel�.��� .+�]� .+���  �� Orientation$ Vertical=�$	��Top=�.+��� $��FTL and Planet Generation��$��24(��� $ 
Horizontal=�.+��� $ Vertical=�$��10,0,0,0q�.+��� $��Hex Coordinates���� $ 
Horizontal=�$��0,5,0,0q�.+��� $��X��$��0,0,5,0q��� -    ��Name$ hexXCoordinateTextBox��$��40���� $ 
Horizontal=�$��0,5,0,0q�.+��� $��Y��$��0,0,5,0q��� -   $ hexYCoordinateTextBox��$��40���� $ Vertical=�$��20,0,0,0q�.+��� $	��FTL��$��Center=��� $ 
Horizontal=�$��0,5,0,0q�.+��� $��Roll 1��$��0,0,5,0q��� -   $ ftlRoll1TextBox��$��40���� $ 
Horizontal=�$��0,2,0,0q�.+��� $��Roll 2��$��0,0,5,0q��� -   $ ftlRoll2TextBox��$��40��{���  �� ElementName$ ftlExplorerCheckbox��$ 	IsChecked��� -    ��Name$ ftlExplorerCheckbox��$��Explorer��	 d� 	IsChecked$	 FalseY�$��0,2,0,0q��� -   $
��Roll��$��50��$��0,2,0,0q��� $ Vertical=�$��20,0,0,0q�.+��� $��Planetary Generation��$��Center=��� $ 
Horizontal=�$��0,5,0,0q�.+��� $��Roll 1��$��0,0,5,0q��� -   $% planetaryGenerationRoll1TextBox��$��40���� $ 
Horizontal=�$��0,2,0,0q�.+��� $��Roll 2��$��0,0,5,0q��� -   $% planetaryGenerationRoll2TextBox��$��40���� $�� ��$��0,2,0,0q��� -	   $
��Roll��$��50��$��0,2,0,0q��� $ Vertical=�$��20,0,0,0q�.+��� $��Generation Settings��$��Center=��� -
   $" forceSentientSpeciesCheckBox��$��Force Sentient Species��$	 FalseY��� -   $ seedHexCheckBox��$��Seed Hex��$
	 TrueY�$��0,10,0,0q��� -   $ seedFTLCheckBox��$��Seed FTL Roll��$	 FalseY��� -   $% seedPlanetaryGenerationCheckBox��$$��Seed Planetary Generation Roll��$	 FalseY��� $ 
Horizontal=�$��0,5,0,0q�.+��� -   $	��100��$��Generate���� -   $��Clear��$��5,0,0,0q�$��60���� $ 
Horizontal=�$��0,20,0,0q�.+��� $��
FTL Result��$��0,0,5,0q��� ���� $ FTLTravelResult�  EnumSpaceConverter
 �� 	Converter#
 [ �� -    ��Name$ generatedPlanets������ $ GeneratedSystem����� .R��� $ 
Horizontal=�$	��Top=�$
��Left=����� .R��� $ Vertical=�.+��� $ 
Horizontal=�.+��� $	 FalseY��� $��5,0,0,0q����� *Classification+#
 [ �� $��Radiation Level:��$��20,0,5,0q��� ���� *	Radiation+#
 [ �� $��20,0,0,0q����� *Age+#
 [ �� ���� *CelestialBodies+���� .R��� $ Vertical=�.+��� $ 
Horizontal=�.+��� ���� *CelestialType+#
 [ �� $��20,0,0,0q����� *TerraformingTier+#
 [ �� $��20,0,0,0q����� *ResourceValue+�� $��20,0,0,0q����� *StageOfLife+#
 [ �� ���� *	Sentients+���� .R��� $ Vertical=�.+��� $ 
Horizontal=�.+��� ���� *	TechLevel+#
 [ �� $ Vertical=�$��20,0,0,0q�.+��� $��Civilization Traits��$��Center=�$��0,0,5,0q��� ���� *Traits+���� .R��� ���� #
 [ �� $ Vertical=�$��20,0,0,0q�.+��� $��Race Classification��$��Center=�$��0,0,5,0q��� ���� *Classifications+���� .R��� ���� #
 [ 