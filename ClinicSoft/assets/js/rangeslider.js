$(function() {
	'use strict'
	
	$('.rangeslider1').ionRangeSlider();
	$('.rangeslider2').ionRangeSlider({
		min: 10,
		max: 100,
		from: 550
	});
	$('.rangeslider3').ionRangeSlider({
		type: 'double',
		grid: true,
		min: 0,
		max: 1000,
		from: 200,
		to: 800,
		prefix: '$'
	});
	$('.rangeslider4').ionRangeSlider({
		type: 'double',
		grid: true,
		min: -1000,
		max: 1000,
		from: -500,
		to: 500,
		step: 250
	});
});