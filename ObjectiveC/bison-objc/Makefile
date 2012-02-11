# These are just constants, that should be modified
# for your program
#
#######################################
#The name of the binary make will create
PROGRAM = objcparser
#The actual name of your lex/flex file	
LEXFILE = ObjectiveC.l
#The actual name of the yacc/bison file
YACCFILE = ObjectiveC.y
#Some source files that should be compiled in
CFILES = main.cpp
#General .h files used in your program 
#that everything should be compiled against
#HFILE = structures.h
#flags to your Compiler
CFLAGS = -g
#CXX_CFLAGS = -ObjC -framework Foundation

# ANSI C
CC		= g++
CC_COMPILE	= $(CC) -c $(OPTFLAGS) $(CFLAGS) $(CC_CFLAGS) $(CC_SYSCFLAGS)
CC_LINK		= $(CC) $(LDFLAGS) $(CC_LDFLAGS) $(CC_SYSLDFLAGS)
CC_CFLAGS 	=
CC_LDFLAGS	=
# C++
CXX		= g++
CXX_COMPILE	= $(CXX) -c  $(OPTFLAGS) $(CFLAGS) $(CXX_CFLAGS) $(CXX_SYSCFLAGS)
CXX_LINK	= $(CXX) $(LDFLAGS) $(CXX_LDFLAGS) $(CXX_SYSLDFLAGS)
CXX_CFLAGS 	= 
CXX_LDFLAGS	=

LEXER = flex
PARSER = bison


# Compilation Rules -- Repeat the rules for all of the different
# naming conventions.
#
.cxx.o:	; $(CXX_COMPILE) $<
.cpp.o:	; $(CXX_COMPILE) $<
.cc.o:	; $(CXX_COMPILE) $<
.C.o:	; $(CXX_COMPILE) $<

.cxx:	
	$(CXX_COMPILE) $<
	$(CXX_LINK) -o $@ $*.o $(LIBRARIES)
.cpp:	
	$(CXX_COMPILE) $<
	$(CXX_LINK) -o $@ $*.o $(LIBRARIES)
.cc:	
	$(CXX_COMPILE) $<
	$(CXX_LINK) -o $@ $*.o $(LIBRARIES)
.C:	
	$(CXX_COMPILE) $<
	$(CXX_LINK) -o $@ $*.o $(LIBRARIES)


# Compile plain C code
.c.o:	; $(CC_COMPILE) $<
.c:	
	$(CC_COMPILE) $<
	$(CC_LINK) -o $@ $*.o $(LIBRARIES)


##################################################
# Most of the following don't need to be messed with 
##################################################
LFLAGS = #these are flags that are options actually for lex/flex
PARSEFLAGS= -dvt #Defines flags that either yacc or bison will want/need for you
FLEXFLAGS = #Flags specific to flex
LEXFLAGS = #Flags specific to lex
BISONFLAGS = -y -v#Flags specific to bison
YACCFLAGS = #Flags specific to Yacc

##################################################
#
# You shouldn't need to change anything else
#
##################################################

ifeq ($(LEXER), flex) 
	#use the flex flags for GCC
	LEXCCFLAGS = -lfl
	LEXERFLAGS = ${LFLAGS} ${FLEXFLAGS}
else				#else lex is used
	#lex flags for GCC
	LEXCCFLAGS = -ll
	LEXERFLAGS = ${LFLAGS} ${LEXFLAGS}
endif

ifeq ($(PARSER), bison)				 #if bison chosen, need to specify yacc output files
	#the -y outputs y.tab.c file.
	IPARSEFLAGS = ${PARSEFLAGS}  ${BISONFLAGS}
else						 #yacc was chosen for the parser
	#default flags for yacc
	IPARSEFLAGS = ${PARSEFLAGS} ${YACCFLAGS}
endif

# compute the OFILES
OFILES = ${CFILES:.cpp=.o}

# all of the .o files that the program needs
OBJECTS = y.tab.o lex.yy.o ${OFILES}

# How to make the whole program
${PROGRAM} : ${OBJECTS}
	${CC} ${CFLAGS} ${OBJECTS} -o ${PROGRAM} ${LEXCCFLAGS}


# 
# Turn the parser.y file into y.tab.c using "yacc"
# 
# Also, yacc generates a header file called "y.tab.h" which lex needs
# It's almost always the same, so we'll have lex use a different
# file and just update it when y.tab.h changes (to save compiles)
#
y.tab.c : ${YACCFILE} ${HFILES}
	${PARSER} ${IPARSEFLAGS} ${YFLAGS} ${YACCFILE}
y.tab.o: y.tab.c
	${CC} ${CFLAGS} -c y.tab.c
y.tab.h: y.tab.c
parser.h: y.tab.h
	cmp -s y.tab.h parser.h || cp y.tab.h parser.h

# 
#  Turn the scanner.l file into lex.yy.c using "lex"
# 
lex.yy.c : ${LEXFILE} ${HFILE}
	${LEXER} ${LFLAGS} ${LEXFILE}
lex.yy.o: lex.yy.c
	${CC} ${CFLAGS} -c lex.yy.c

#
# File dependencies
#
${OFILES}: ${HFILE} 
#parser.h

clean:
	/bin/rm -f *.o lex.yy.c y.tab.c c.tab.h c.output c.tab.c ${PROGRAM} parser.h y.output y.tab.h core *.*~ *~ #*#
