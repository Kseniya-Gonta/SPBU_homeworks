#!/bin/bash

source config.sh 
function cloning() {
	rm -rf $FOLDER
	if [ git clone $REPOSITORY &> clone.txt ]
		then email_ok
	else email_fail clone.txt
	fi
}


function checking() {
	xbuild $SOLUTION &> build.txt
	
	while read p; do
		if [ ! -f $p ]
		then
			email_fail build.txt
			exit 1
		fi
	done < check.txt
	
	
}

function email_ok() {
	
	mail  -s "Build" $EMAIL_LOG <<< "It's ok!"
}

function email_fail() {
	mutt -a $1 -s "Build" -- $EMAIL_LOG <<< "Build failed!" 
}

cloning
checking
email_ok
