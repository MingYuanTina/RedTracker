// Calculator
// INPUT: <user#, #######> where the digits are tddmmyy, t=1 for start date, t=2 for end date
// OUTPUT: < user#, ddmmyy, ddmmyy > first date represents the estimated next start date, 
//			the second date represents the estimated ovulation date


// TO DO : THIS NEEDS ACCESS TO THE DATABASE, LET'S SAY IT WILL BE A STRUCTURE??? CLASS???? MAP????
// WE NEED FUNCTIONS THAT HAS ACCESS TO THE DATABASE 

#include <vector>
using namespace std;

vector<int> ovuCalc (pair<int, int> inputDate) {
	vector<int> outputDates;
	outputDates.push_back(inputDate.first);
	int nextStart = 0;
	int nextOvu = 0;
	int mensCycle = 28; //default menstrul cycle is 28 days
	int type = inputDate.second/1000000;
	int date = (inputDate.second % 1000000) /10000;
	int month =(inputDate.second % 10000) /100;
	int year = (inputDate.second % 100);
	// check if the user# is in the database
	// if she is then log the input into her database
	// and grab the average period cycle of the user from her database
	if (inDatabase(inputDate.first)) { //inDatabase returns true if user# is in database, false otherwise
		updateDatabase(inputDate.first, inputDate.second); //updateDatabase will log in the new input date
		mensCycle = getCycle(inputDate.first); //getCycle returns the average mestrul cycle of the unique user
	} else { // we need to add the new user to the database
		createUser(inputDate.first, inputDate.second); //create and log the new user with her first start date
		// for the new user, we will use the default menstrul cycle of 28 days
	}
	int ovuCycle = mensCycle/2;
	if (type == 1) { //if the start date of period is inputted
		// calculate the estimated next start date by adding mensCycle to the date
		nextStart = date + mensCycle;
		nextOvu = date + ovuCycle;
		if (month == 1 || month ==3 || month==5 ||month ==7||month==8||month==10) {
			if (nextStart > 31) {
				nextStart = (nextStart - 31) * 10000 + (month + 1) * 100 + year;
			} else {
				nextStart = nextStart * 10000 + month * 100 + year;
			}
		} else if (month == 12) {
			if (nextStart > 31) {
				nextStart = (nextStart - 31) * 10000 + 100 + year + 1;
			} else {
				nextStart = nextStart * 10000 + month * 100 + year;
			}
		} else {
			if (nextStart > 30) {
				nextStart = (nextStart - 30) * 10000 + (month + 1) * 100 + year;
			} else {
				nextStart = nextStart * 10000 + month * 100 + year;
			}
		} // THIS COULD BE BETTER.....DO THE SAME FOR OVULATION DATE...
		nextOvu = nextOvu * 10000 + month * 100 + year; // just for now...

	} else if (type == 2) { //if the end date of period is inputted
		// do something ...... ????
	} else {
		// do something
	}
	outputDates.push_back(nextStart);
	outputDates.push_back(nextOvu);

	return outputDates;
}
