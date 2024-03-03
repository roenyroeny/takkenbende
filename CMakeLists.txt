cmake_minimum_required(VERSION 3.25)
project(takkenbende LANGUAGES CSharp)

file(GLOB source *.cs Properties/*.cs)

add_executable(plot ${source})
set_property(TARGET plot PROPERTY VS_DOTNET_REFERENCES
      "Microsoft.CSharp"
      "System"
      "System.Xml"
      "System.Xml.Linq"
      "System.Windows.Forms"
      "System.Drawing"
      "System.Data")

set_target_properties(plot PROPERTIES RUNTIME_OUTPUT_DIRECTORY "${CMAKE_CURRENT_SOURCE_DIR}/bin")
set_target_properties(plot PROPERTIES RUNTIME_OUTPUT_DIRECTORY_DEBUG "${CMAKE_CURRENT_SOURCE_DIR}/bin")
set_target_properties(plot PROPERTIES RUNTIME_OUTPUT_DIRECTORY_RELEASE "${CMAKE_CURRENT_SOURCE_DIR}/bin")
set_target_properties(plot PROPERTIES RUNTIME_OUTPUT_DIRECTORY_RELWITHDEBINFO "${CMAKE_CURRENT_SOURCE_DIR}/bin")
set_target_properties(plot PROPERTIES VS_DEBUGGER_WORKING_DIRECTORY "${CMAKE_CURRENT_SOURCE_DIR}/bin")

set_property(GLOBAL PROPERTY VS_STARTUP_PROJECT plot)
