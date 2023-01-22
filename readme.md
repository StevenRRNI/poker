# Poker

## Poker Scorer
The PokerScorer class is used to calculate the best hand available from a list of own (hole) or shared (community) cards according to the variant supplied in the constructor. The default scoring uses Pokers standard hand rankings which can be overriden by supplying a rankings list to the classes constructor. 

To implement a custom Hand inherit from the Hand class and implement the required methods. Add this hand to a custom ranking lists in the PokerScorer classes constructor.

## Comments
Hands use a TryGetHand method which returns the cards making up the hand if the hand is possible. This wasn't a requirement but could be used as part of an enhancement to return the cards that make up the best hand. It would also be required for comparing hands to find the best score. Its currently only partially implemented as only some hands return the correct highest combination.