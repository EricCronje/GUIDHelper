##########################################
#            (       )                   #
#  *   )  (  )\ ) ( /(                   #
#` )  /(( )\(()/( )\())                  #
# ( )(_))((_)/(_)|(_)\                   #
#(_(_()|(_)_(_))   ((_)                  #
#|_   _|| _ )_ _| / _ \                  #
#  | |  | _ \| | | (_) |                 #
#  |_|  |___/___| \___/  Version 4.0.1	 #
#################################################################################################################################################################
# Purpose:																			#
# ---------																			#
# Generate the sha256sum command to run on the command line to generate the sha256 file. Used to check if the dll's changed					#
# Create hashes for all the dll's and exe's.															#
# 																				#
# Usage:																			#
# ---------																			#
# ./sha256gen.sh <DotNetSolutionsFileSLN>															#
#																				#
# Lessons:																			#
# ---------																			#
# The sh file can be run by adding ./ e.g ./sha256gen.sh													#
# 																				#
# History:																			#
# ---------																			#
#1 - Add - Created the program ./sha256gen.sh								-	TB10	-	20240916	- v1.0.0	#
#2 - Add - Remove the sha256 file.				                                        -       TB10    -       20240916        - v2.0.0        #
#3 - Add - Dotnet build the ListPAgination solution - build the command to sha256sum the dlls		-	TB10	-	20240916	- v3.0.0	#
#4 - Add - Add the while read line part and the diff check.						-	TB10	-	20240916	- V3.0.1	#
#5 - Add - Parameters - for the projectfile $1								-	TB10	-	20240917	- V4.0.1	#
#################################################################################################################################################################
rm sha256;dotnet build $1 | grep -i ">" | awk '{print $3}'| sed 's/C:/\/c/g'| sed 's/\\/\//g' | awk '{print "sha256sum " $1}' | while read line; do $line >> sha256; done; #1 #2 #3 #4 #5
